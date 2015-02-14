using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaEF_BO.DAL;
using AgenciaEF_BO.Models;
using System.Collections;
using System.Data;


namespace AgenciaEF_BO.BO
{
    public class Facturar
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public int FacturaGenerada { set; get; }

        /*en esta version van sin codigos fiscales*/
        public bool CrearFacturaCargoVarios(ArrayList pCargVar, int iCteId, int iUsuarioId, int iSucId, int iTipoFiscal)
        {
            bool bRetorno = true;

            Recibos oRecibos = new Recibos();

            decimal MontoFact = 0; ;
            decimal MontoItebis = 0;

            oRecibos.COUNTER_ID = iUsuarioId;
            oRecibos.CTE_ID = iCteId;
            oRecibos.ESTADO_ID = 14;   //Cobrado
            oRecibos.F_COBRO = DateTime.Now; //Hay que ver si es de credito.
            oRecibos.F_VCTO = DateTime.Now;  //Depende del cliente para la fecha del vencimiento.
            oRecibos.FECHA = DateTime.Now;
            oRecibos.FECHA_CREA = DateTime.Now;
            oRecibos.FECHA_MODIF = DateTime.Now;
            oRecibos.IMPORTE_CTA = 0;
            oRecibos.IMPORTE_TOTAL = 0;
            oRecibos.NUM_FISCAL = "NA"; //Numero Fiscal
            oRecibos.NUM_REC = -1;
            oRecibos.RECIBO_ID_ANUL = -1;
            oRecibos.SUC_ID = iSucId;
            oRecibos.TIP_FISCAL = iTipoFiscal;
            oRecibos.TIPO_REC_ID = 54; //FT10 FACTURA DE CARGOS VARIOS.
            oRecibos.USER_CREA = "NA";
            oRecibos.USER_MODIFICA = "NA";
            oRecibos.REC_CREDITO = true;

            foreach (int iCargoVario in pCargVar)
            {

                var sQry = unitOfWork.CargosVariosRepository.GetByID(iCargoVario);

                RecibosDet oRecDet = new RecibosDet();
                oRecDet.BLT_NUMERO = -1;
                oRecDet.RECIBO_ID = oRecibos.RECIBO_ID;
                oRecDet.CARGO_ID = sQry.Cargos.CARGO_ID;
                oRecDet.MONTO_LOCAL = sQry.IMPORTE;
                if (sQry.Cargos.CAR_ITBIS == true && sQry.Cargos.ITBIS > 0)
                {
                    oRecDet.MONTO_ITBIS = Math.Round((sQry.IMPORTE * sQry.Cargos.ITBIS) / 100, 2);
                    oRecDet.MONTO_TOTAL = sQry.IMPORTE + oRecDet.MONTO_ITBIS;
                }
                else
                {
                    oRecDet.MONTO_ITBIS = 0;
                    oRecDet.MONTO_TOTAL = sQry.IMPORTE;
                }

                MontoFact += oRecDet.MONTO_TOTAL;
                MontoItebis += oRecDet.MONTO_ITBIS;

                unitOfWork.RecibosDetRepository.Insert(oRecDet);
                sQry.F_FACT = oRecibos.FECHA;
                sQry.ESTADO_ID = 19; //Facturado
                unitOfWork.CargosVariosRepository.Update(sQry);

            }
            oRecibos.IMPORTE_ITEBIS = MontoItebis;
            oRecibos.IMPORTE_TOTAL = MontoFact + MontoItebis;

            //BUSCA COMPROVANTE FISCAL.
            //oRecibos.NUM_FISCAL
            /*not yet
            var oClientes = unitOfWork.ClientesRepository.GetByID(oRecibos.CTE_ID);

            oRecibos.TIP_FISCAL = oClientes.CTE_TIPO_FISCAL;
            oRecibos.NUM_FISCAL = FindNextNCF(oRecibos.TIP_FISCAL);
            */

           
            oRecibos.ESTADO_ID = 13;   //Facturado
            oRecibos.IMPORTE_CTA = 0;
            //oRecibos.F_VCTO = oRecibos.F_VCTO.AddDays(Convert.ToDouble(oClientes.CTE_DIAS_CREDITOS)).Date;

            var oClientes = unitOfWork.ClientesRepository.GetByID(iCteId);

            oClientes.CTE_BALANCE_DISPONIBLE = oClientes.CTE_BALANCE_DISPONIBLE - oRecibos.IMPORTE_TOTAL;
            unitOfWork.ClientesRepository.Update(oClientes);

         
            unitOfWork.RecibosRepository.Insert(oRecibos);

             try
                {
                    unitOfWork.Save();
                    FacturaGenerada = oRecibos.RECIBO_ID;
                  
                }

                catch (System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        string s = "";
                        /*
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        */


                        foreach (var ve in eve.ValidationErrors)
                        {
                            s += ve.ErrorMessage + "\n";
                            /*Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);*/
                        }
                       // MessageBox.Show("Existen los siguientes errores:" + s, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw e;
                    }
                    //throw;
                }
                catch (DataException ex)
                {

                    throw ex;
                }



            return bRetorno;

        }



        public bool RegistrarCobro(ArrayList pRecibos, int  piCteId, int iUsuarioId, int iSucId, int iTipoFiscal, decimal pdMontoPagar,
            decimal dMontoEfectivo, decimal dMontoOtros, decimal dDevolucion, DAL.dsDatos.DatosPagoDataTable pDatosPago)
        {
            ArrayList oRecibosCobrados = new ArrayList();
            
            bool bRetorno = false;

            decimal dMontoPagar = pdMontoPagar;

            MovCaja oCaja = new MovCaja();
            oCaja.FPAGO_ID = -1;
            oCaja.FECHA = DateTime.Now;
            oCaja.CTE_ID = piCteId;
            oCaja.COUNTER_ID = iUsuarioId;
            oCaja.IMPORTE = dMontoPagar;
            oCaja.SUC_ID = iSucId;

            oCaja.TIP_MOV = 55;// Registor de cobros;

            unitOfWork.MovCajaRepository.Insert(oCaja);

            //

            Pagos oPagos = new Pagos();

            oPagos.CTE_ID = piCteId;
            oPagos.COUNTER_ID = iUsuarioId;
            oPagos.ESTADO_ID = 14;  /*cobrado*/
            oPagos.F_PAGO = oCaja.FECHA;
            oPagos.IMP_PAGO = dMontoPagar;
            oPagos.SUC_ID = iSucId;

            oPagos.TIPO_ID = 48; /*efectivo*/

            if (pDatosPago.Rows.Count > 0)
                oPagos.TIPO_ID = Convert.ToInt32(pDatosPago.Rows[0]["TipoPago"]);

            unitOfWork.PagosRepository.Insert(oPagos);

            //

            foreach (int i in pRecibos)
            {
                var oRecibos = unitOfWork.RecibosRepository.GetByID(i);

                MovCajaRecibos oCajaRecibos = new MovCajaRecibos();
                oCajaRecibos.MOVCAJA_ID = oCaja.MOVCAJA_ID;
                oCajaRecibos.RECIBO_ID = i;

                PagosRecibos oPagosRec = new PagosRecibos();

                oPagosRec.PAGO_ID = oPagos.PAGO_ID;
                oPagosRec.RECIBO_ID = i;

              

                if (oRecibos.IMPORTE_CTA == 0)
                {
                    if (pdMontoPagar >= oRecibos.IMPORTE_TOTAL)
                    {
                        oCajaRecibos.IMPORTE_PAGADO = oRecibos.IMPORTE_TOTAL;

                        oPagosRec.IMPORTE_PAGADO = oRecibos.IMPORTE_TOTAL;

                        oRecibos.IMPORTE_CTA = oRecibos.IMPORTE_TOTAL;
                        oRecibos.ESTADO_ID = 14; //cobrado;
                        pdMontoPagar = pdMontoPagar - oRecibos.IMPORTE_TOTAL;
                    }
                    else
                    {
                        oCajaRecibos.IMPORTE_PAGADO = pdMontoPagar;

                        oPagosRec.IMPORTE_PAGADO = pdMontoPagar;

                        oRecibos.IMPORTE_CTA = pdMontoPagar;
                        pdMontoPagar = 0;
                    }
                }
                else
                {/* ha que ver cuando tiene importe a cuenta*/


                    if (pdMontoPagar >= (oRecibos.IMPORTE_TOTAL - oRecibos.IMPORTE_CTA) )
                    {
                        oCajaRecibos.IMPORTE_PAGADO = oRecibos.IMPORTE_TOTAL;

                        oPagosRec.IMPORTE_PAGADO = oRecibos.IMPORTE_TOTAL;

                        oRecibos.IMPORTE_CTA = oRecibos.IMPORTE_TOTAL;
                        oRecibos.ESTADO_ID = 14; //cobrado;
                        pdMontoPagar = pdMontoPagar - (oRecibos.IMPORTE_TOTAL - oRecibos.IMPORTE_CTA);
                    }
                    else
                    {
                        oCajaRecibos.IMPORTE_PAGADO = pdMontoPagar;

                        oPagosRec.IMPORTE_PAGADO = pdMontoPagar;

                        oRecibos.IMPORTE_CTA += pdMontoPagar;
                        pdMontoPagar = 0;
                    }


                }

                oRecibosCobrados.Add(i);

                unitOfWork.RecibosRepository.Update(oRecibos);

                unitOfWork.MovCajaRecibosRepository.Insert(oCajaRecibos);

                unitOfWork.PagosRecibosRepository.Insert(oPagosRec);

                if(pdMontoPagar == 0)
                {
                    break;
                }


            }

          
          

          


           


                //Datos pago
            foreach (DataRow dr in pDatosPago.Rows)
            {
                DatosPago oDatosPagos = new DatosPago();
                oDatosPagos.BANCO_ID = Convert.ToInt32(dr["Banco"]);
                oDatosPagos.FECHA_VENC = Convert.ToDateTime(dr["Fecha"]);
                oDatosPagos.IMPORTE = Convert.ToDecimal(dr["Importe"]);
                oDatosPagos.PAGO_ID = oPagos.PAGO_ID;
                oDatosPagos.NUMERO = dr["Numero"].ToString();

                unitOfWork.DatosPagoRepository.Insert(oDatosPagos);


            }
            //Estao esta doble hay que revisarlo algun dia
            foreach (int i in oRecibosCobrados)
            {
                PagosRecibos oPagosRec = new PagosRecibos();

                oPagosRec.PAGO_ID = oPagos.PAGO_ID;
                oPagosRec.RECIBO_ID = i;

                unitOfWork.PagosRecibosRepository.Insert(oPagosRec);
            }
          

            var oClientes = unitOfWork.ClientesRepository.GetByID(piCteId);

            oClientes.CTE_BALANCE_DISPONIBLE = oClientes.CTE_BALANCE_DISPONIBLE + dMontoPagar;
            unitOfWork.ClientesRepository.Update(oClientes);

           
            //

            try
            {
                unitOfWork.Save();
                FacturaGenerada = oCaja.MOVCAJA_ID;
                bRetorno = true;
             
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    string s = "";
                    /*
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    */


                    foreach (var ve in eve.ValidationErrors)
                    {
                        s += ve.ErrorMessage + "\n";
                        /*Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);*/
                    }
                    // MessageBox.Show("Existen los siguientes errores:" + s, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw e;
                }
                //throw;
            }
            catch (DataException ex)
            {

                throw ex;
            }

            return bRetorno;

        }

        //x.FormaPago, x.MontoEfectivo, x.MontoOtros, x.Devolucion, x.DatosPago, 
        public bool CrearFactura(decimal dMontoEfectivo, decimal dMontoOtros, decimal dDevolucion, DAL.dsDatos.DatosPagoDataTable pDatosPago,
                  int iCteId, int iTipoFiscal, int iSucId, int iUsuarioId, ArrayList pBultos, dsDatos.CorrespondenciaDataTable pTableCorr, decimal pdMontoFacturado, bool bCredito)
        {
            bool bRetornoCorr = true;
            bool bRetorno = true;
            Recibos oRecibos = new Recibos();
            decimal MontoFact = 0; ;
            decimal MontoItebis = 0; 


            //1. CrearLos bultos de la mensajeria.
            if (pTableCorr.Rows.Count > 0)
            {
                bRetornoCorr = RegistroCorrespondencia(iCteId, iSucId, pTableCorr, iUsuarioId, ref pBultos);
            }

            if (bRetornoCorr == true)
            {
                //Si funciona la correspondencia, 

                oRecibos.COUNTER_ID = iUsuarioId;
                oRecibos.CTE_ID = iCteId;
                oRecibos.ESTADO_ID = 14;   //Cobrado
                oRecibos.F_COBRO = DateTime.Now; //Hay que ver si es de credito.
                oRecibos.F_VCTO = DateTime.Now;  //Depende del cliente para la fecha del vencimiento.
                oRecibos.FECHA = DateTime.Now;
                oRecibos.FECHA_CREA = DateTime.Now;
                oRecibos.FECHA_MODIF = DateTime.Now;
                oRecibos.IMPORTE_CTA = pdMontoFacturado;
                oRecibos.IMPORTE_TOTAL = pdMontoFacturado;
                oRecibos.NUM_FISCAL = "NA"; //Numero Fiscal
                oRecibos.NUM_REC = -1;
                oRecibos.RECIBO_ID_ANUL = -1;
                oRecibos.SUC_ID = iSucId;
                oRecibos.TIP_FISCAL = iTipoFiscal;
                oRecibos.TIPO_REC_ID = 1; //FT00  RECEPCION.
                oRecibos.USER_CREA = "NA";
                oRecibos.USER_MODIFICA = "NA";
                oRecibos.REC_CREDITO = bCredito;

               
 
                foreach(object s in pBultos)
                {
                   
                    int iBltNumero = Convert.ToInt32(s);     
                
                  
                    var sQueryValores = unitOfWork.BultosValoresRepository.Get(filter: a=>a.BLT_NUMERO == iBltNumero && a.CargosProducto.Cargos.CAR_NCF == true);
                    foreach(var sQry in sQueryValores)
                    {
                        RecibosDet oRecDet = new RecibosDet();
                        oRecDet.BLT_NUMERO = iBltNumero;
                        oRecDet.RECIBO_ID = oRecibos.RECIBO_ID;
                        oRecDet.CARGO_ID = unitOfWork.CargosProductoRepository.GetByID(sQry.CARGO_PROD_ID).CARGO_ID;
                        
                        oRecDet.MONTO_LOCAL = sQry.BVA_MONTO_LOCAL;
                        if (sQry.CargosProducto.Cargos.CAR_ITBIS == true && sQry.CargosProducto.Cargos.ITBIS > 0)
                        {
                            oRecDet.MONTO_ITBIS = Math.Round((sQry.BVA_MONTO_LOCAL * sQry.CargosProducto.Cargos.ITBIS) / 100, 2);
                            oRecDet.MONTO_TOTAL = sQry.BVA_MONTO_LOCAL + oRecDet.MONTO_ITBIS;
                        }
                        else
                        {
                            oRecDet.MONTO_ITBIS = 0;
                            oRecDet.MONTO_TOTAL = sQry.BVA_MONTO_LOCAL;
                        }
                            
                        MontoFact += oRecDet.MONTO_TOTAL;
                        MontoItebis += oRecDet.MONTO_ITBIS;

                        unitOfWork.RecibosDetRepository.Insert(oRecDet);
                        var sQueryButos = unitOfWork.BultosRepository.GetByID(iBltNumero); //Entregado al cliente;
                        sQueryButos.BLT_ESTADO_ID = 5;//Entregado al cliente
                        sQueryButos.BLT_FECHA_ENTREGADO = DateTime.Now;
                        unitOfWork.BultosRepository.Update(sQueryButos);

                    }
                  

                }
                oRecibos.IMPORTE_ITEBIS = MontoItebis;
                //oRecibos.IMPORTE_TOTAL = MontoFact + MontoItebis;

                //BUSCA COMPROVANTE FISCAL.
                //oRecibos.NUM_FISCAL
                var oClientes = unitOfWork.ClientesRepository.GetByID(oRecibos.CTE_ID);

                oRecibos.TIP_FISCAL = oClientes.CTE_TIPO_FISCAL;
                oRecibos.NUM_FISCAL = FindNextNCF(oRecibos.TIP_FISCAL);


                if (bCredito)
                {
                    oRecibos.ESTADO_ID = 13;   //Facturado
                    oRecibos.IMPORTE_CTA = 0;
                    oRecibos.F_VCTO = oRecibos.F_VCTO.AddDays(Convert.ToDouble(oClientes.CTE_DIAS_CREDITOS)).Date;
                }
                else
                    oRecibos.IMPORTE_CTA = oRecibos.IMPORTE_TOTAL;


               

                unitOfWork.RecibosRepository.Insert(oRecibos);
                //
                //registrar el movimiento de caja
                MovCaja oCaja = new MovCaja();
                oCaja.FPAGO_ID = -1;
                oCaja.FECHA = DateTime.Now;
                oCaja.CTE_ID = iCteId;
                oCaja.COUNTER_ID = iUsuarioId;
                oCaja.IMPORTE = pdMontoFacturado;
                oCaja.SUC_ID = iSucId;
                if(bCredito)
                   oCaja.TIP_MOV = 53;// "MV001"  Facturacion de mercancia;
                else
                   oCaja.TIP_MOV = 51;// "MV001"  Facturacion de mercancia;

                MovCajaRecibos oCajaRec = new MovCajaRecibos();
                oCajaRec.MOVCAJA_ID = oCaja.MOVCAJA_ID;
                oCajaRec.RECIBO_ID = oRecibos.RECIBO_ID;


                unitOfWork.MovCajaRepository.Insert(oCaja);

                unitOfWork.MovCajaRecibosRepository.Insert(oCajaRec);

                if (!bCredito)
                {                 //Datos pago

                    Pagos oPagos = new Pagos();
                    oPagos.CTE_ID = iCteId;
                    oPagos.COUNTER_ID = oCaja.COUNTER_ID;
                    oPagos.ESTADO_ID = 14;
                    /*
                     * 14  COBRADO
                        15  ANULADO
                     */
                    oPagos.F_PAGO = oCaja.FECHA;
                    oPagos.IMP_PAGO = pdMontoFacturado;
                    oPagos.MOVCAJA_ID = oCaja.MOVCAJA_ID;
                    oPagos.SUC_ID = iSucId;
                    oPagos.TIPO_ID = 48; /*efectivo*/

                    if (pDatosPago.Rows.Count > 0)
                        oPagos.TIPO_ID = Convert.ToInt32(pDatosPago.Rows[0]["TipoPago"]);

                    unitOfWork.PagosRepository.Insert(oPagos);

                    foreach (DataRow dr in pDatosPago.Rows)
                    {
                        DatosPago oDatosPagos = new DatosPago();
                        oDatosPagos.BANCO_ID = Convert.ToInt32(dr["Banco"]);
                        oDatosPagos.FECHA_VENC = Convert.ToDateTime(dr["Fecha"]);
                        oDatosPagos.IMPORTE = Convert.ToDecimal(dr["Importe"]);
                        oDatosPagos.PAGO_ID = oPagos.PAGO_ID;
                        oDatosPagos.NUMERO = dr["Numero"].ToString();

                        unitOfWork.DatosPagoRepository.Insert(oDatosPagos);


                    }

                    PagosRecibos oPagosRec = new PagosRecibos();
                    oPagosRec.PAGO_ID = oPagos.PAGO_ID;
                    oPagosRec.RECIBO_ID = oRecibos.RECIBO_ID;

                    unitOfWork.PagosRecibosRepository.Insert(oPagosRec);


                }
                else
                {
                    oClientes.CTE_BALANCE_DISPONIBLE = oClientes.CTE_BALANCE_DISPONIBLE - oRecibos.IMPORTE_TOTAL;
                    unitOfWork.ClientesRepository.Update(oClientes);
                    
                }

                //

                try
                {
                    unitOfWork.Save();
                    FacturaGenerada = oRecibos.RECIBO_ID;
                }

                catch (System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        string s = "";
                        /*
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        */


                        foreach (var ve in eve.ValidationErrors)
                        {
                            s += ve.ErrorMessage + "\n";
                            /*Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);*/
                        }
                       // MessageBox.Show("Existen los siguientes errores:" + s, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw e;
                    }
                    //throw;
                }
                catch (DataException ex)
                {

                    throw ex;
                }


            }



            return bRetorno;
        }



      
        string FindNextNCF( int iTipFiscal)
        {
            string sRetorno = "";

            NumeroFiscal oFiscal = unitOfWork.NumeroFicalRepository.Get(filter: xy => xy.TIPO_ID == iTipFiscal).FirstOrDefault();

            if (oFiscal != null)
            {
                sRetorno = oFiscal.PREFIJO + oFiscal.SECUENCIA.ToString().PadLeft(6,'0');

                oFiscal.SECUENCIA += 1;

                unitOfWork.NumeroFicalRepository.Update(oFiscal);
       

            }

            
            return sRetorno;
        }


        bool RegistroCorrespondencia(int iCteId, int iSucId, dsDatos.CorrespondenciaDataTable pTableCorr, int iUsuarioId,ref  ArrayList pBultos)
        {
            bool bRetorno = false;


            try
            {



                foreach (DataRow dr in pTableCorr.Rows)
                {
                    Bultos oButos = new Bultos();


                    oButos.ALM_CODIGO = 0;
                    oButos.BLT_ABIERTO_ADUANA = false;
                    oButos.BLT_ADUANA = false;
                    oButos.BLT_ALTO = 0;
                    oButos.BLT_ANCHO = 0;
                    oButos.BLT_BOLSA_SUCURSAL = "0";
                    oButos.BLT_BOLSA_SUPLIDOR = "0";
                    oButos.BLT_CODIGO_BARRA = "C-" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" +
                                               DateTime.Now.Year.ToString() + "-" + DateTime.Now.Minute.ToString();

                    oButos.BLT_DESPA_SUPLIDOR = DateTime.Now;
                    oButos.BLT_ENTREGAR = true;
                    oButos.BLT_ESTADO_ID = 1;
                    oButos.BLT_FECHA_ENTREGADO = DateTime.Now;
                    oButos.BLT_FECHA_RECEPCION = DateTime.Now;
                    oButos.BLT_GUIA_HIJA = "C-" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" +
                                               DateTime.Now.Year.ToString() + "-" + DateTime.Now.Minute.ToString();
                                               
                    oButos.BLT_HORA_ENTREGADO = "0";
                    oButos.BLT_HORA_RECIBIDO = "0";
                    oButos.BLT_LARGO = 0;
                    oButos.BLT_LIQUIDADOR = "0";
                    oButos.BLT_MANIFIESTO_SUCURSAL = "0";
                    oButos.BLT_MONTO_SELLOS = 0;
                    oButos.BLT_OBSERVACION = "CORRESPONDENCIA";
                    oButos.BLT_PESO = Convert.ToDecimal(dr["Peso"]);
                    oButos.BLT_PESO_REAL = Convert.ToDecimal(dr["Peso"]);
                    oButos.BLT_PESO_SUPLIDOR = Convert.ToDecimal(dr["Peso"]);
                    oButos.BLT_PIEZAS = Convert.ToInt32(dr["Piezas"]);
                    oButos.BLT_PIEZAS_SUPLIDOR = Convert.ToInt32(dr["Piezas"]);
                    oButos.BLT_PONUMBER = "0";
                    oButos.BLT_PORCIENTO_SELLO = 0;
                    oButos.BLT_RECEP_SUPLIDOR = DateTime.Now;
                    oButos.BLT_TRACKING_NUMBER = "NA";
                    oButos.BLT_UBICACION = "NA";
                    oButos.BLT_VALOR_FOB = 0;
                    oButos.BLT_VENTANILLA = 0;
                    oButos.BLT_VOLUMEN = 0;
                    oButos.BLT_WAREHOUSE = "NA";
                    oButos.CON_CODIGO_ID = 7; //Condición Normal
                    oButos.CONTENIDO = dr["Producto"].ToString();
                    oButos.CTE_ID = iCteId;
                    oButos.DEST_ID = -1;
                    oButos.DESTINATARIO = "NA";
                    oButos.FECHA_MODIF = DateTime.Now;
                    oButos.MAN_GUIA = "NA";
                    oButos.MAN_MANIFIESTO = "NA";
                    oButos.ORI_ID = 168; //SDQ
                    oButos.PROD_ID = Convert.ToInt32(dr["ProdId"]);
                    oButos.REMITENTE = "NA";
                    oButos.SUC_ID = iSucId;
                    oButos.UBI_CODIGO = "NA";
                    oButos.USUARIO_ID = iUsuarioId;
                    unitOfWork.BultosRepository.Insert(oButos);

                    unitOfWork.Save();
                    //Agrego los bultos de correspondencia
                    pBultos.Add(oButos.BLT_NUMERO);

                    List<BultosValores> oBultosValores = new List<BultosValores>();


                    CalculoTafiras oTar = new CalculoTafiras();

                    oBultosValores = oTar.CalcularCorrespondencia(oButos.PROD_ID, oButos.BLT_PESO, oButos.BLT_PIEZAS, oButos.CTE_ID);

                    foreach (BultosValores oVal in oBultosValores)
                    {
                        BultosValores oBultosVal = new BultosValores();

                        oBultosVal.BLT_NUMERO = oButos.BLT_NUMERO;
                        oBultosVal.BVA_MONTO = oVal.BVA_MONTO;
                        oBultosVal.BVA_MONTO_APLICAR = oVal.BVA_MONTO_APLICAR;
                        oBultosVal.BVA_MONTO_LOCAL = oVal.BVA_MONTO_LOCAL;
                        oBultosVal.BVA_TASA = oVal.BVA_TASA;
                        oBultosVal.CARGO_PROD_ID = oVal.CARGO_PROD_ID;

                        unitOfWork.BultosValoresRepository.Insert(oBultosVal);

                    }


                    unitOfWork.Save();
                    bRetorno = true;

                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    string s = "";


                    foreach (var ve in eve.ValidationErrors)
                    {
                        s += ve.ErrorMessage + "\n";

                    }
                    throw e;
                }
                //throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return bRetorno;

        }


    }
}
