﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using BO = AgenciaEF_BO;

namespace OpeAgencia2.Operaciones
{
    public partial class frmImportacion : Form
    {
        public frmImportacion()
        {
            InitializeComponent();
        }

        DataSet ds;
        string CodigoAgencia;
        wsAgencias.wsAgenciasSoapClient oAgencias;
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        StringBuilder sErrores = new StringBuilder();

        private void frmImportacion_Load(object sender, EventArgs e)
        {
            oAgencias = new wsAgencias.wsAgenciasSoapClient();
            oAgencias.InnerChannel.OperationTimeout = System.TimeSpan.FromSeconds(20);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CodigoAgencia = Parametros.ParametrosSucursal.CodigoSucursal;
            //((Form1) this.ParentForm).oParamSuc.CodigoSucursal;
            BuscarFacturas();
        }

        void BuscarFacturas()
        {

            string sFecha;
            //Dim ds As New DataSet
            DataSet ds = new DataSet();

            //Dim oAgencias As New wsAgencias.wsAgencias


            //=  new  wsAgencias.wsAgenciasSoap();


            lblMensaje.Visible = true;
            lblMensaje.Text = "[Estableciendo comunicacion con Servidor.]";


            try
            {

                sFecha = DateTimePicker1.Value.Month.ToString().PadLeft(2, '0') + "/" +
                                            DateTimePicker1.Value.Day.ToString().PadLeft(2, '0') + "/" +
                                            DateTimePicker1.Value.Year.ToString();

                ds = oAgencias.FacturasAgencias(CodigoAgencia, sFecha);

                dgFacturas.DataSource = ds.Tables["Facturas"];
                lblMensaje.Text = "[Buscando Facturas]";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "[Error.....]";
                MessageBox.Show("No se puedo hacer conexion con el Servidor " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.chkBultos.Items.Clear();
            lblMensaje.Visible = false;

        }

        //buscar manifiesto
        private void button3_Click(object sender, EventArgs e)
        {


            if (dgFacturas.Rows.Count <= 0)
            {
                MessageBox.Show("No Hay Guias para Importar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }



            lblMensaje.Visible = true;
            lblMensaje.Text = "[Estableciendo comunicacion con Servidor.]";
            lblMensaje.Refresh();

            string FacCodigo = dgFacturas.Rows[dgFacturas.CurrentRow.Index].Cells[0].Value.ToString();
            string DocCodigo = dgFacturas.Rows[dgFacturas.CurrentRow.Index].Cells[1].Value.ToString();


            try
            {
                ds = oAgencias.ManifiestoAgencias(CodigoAgencia, FacCodigo, DocCodigo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puedo hacer conexion con el Servidor " + "\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            chkBultos.Items.Clear();



            foreach (DataRow oRow in ds.Tables[0].Rows)
            {
                lblMensaje.Text = "[Importando registro" + oRow["BLT_NUMERO"].ToString() + " .] ";
                lblMensaje.Refresh();

                if (oRow["BLT_CODIGO_BARRA"] == null || oRow["BLT_CODIGO_BARRA"].ToString().TrimEnd() == "")
                {
                    chkBultos.Items.Add(oRow["BLT_NUMERO"].ToString().PadRight(10, ' ') + "|" + oRow["BLT_GUIA_HIJA"].ToString().PadRight(30, ' ')
                          + "|" + oRow["CTE_NUMERO_EPS"].ToString().PadRight(20, ' ') + "|" + oRow["MAN_GUIA"].ToString().PadRight(20, ' '));

                }
                else
                {
                    chkBultos.Items.Add(oRow["BLT_NUMERO"].ToString().PadRight(10, ' ') + "|" + oRow["BLT_CODIGO_BARRA"].ToString().PadRight(30, ' ')
                            + "|" + oRow["CTE_NUMERO_EPS"].ToString().PadRight(20, ' ') + "|" + oRow["MAN_GUIA"].ToString().PadRight(20, ' '));

                }


            }

            lblMensaje.Visible = false;
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {

            if (TextBox1.Text != "")
            {

                if (SeleccionarEnLista(TextBox1.Text.TrimEnd()) == false)
                {
                    MessageBox.Show("Este Codigo no esta en el manifiesto ..> " + TextBox1.Text.TrimEnd(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                TextBox1.Text = "";
                TextBox1.Select();
            }
        }

        private bool SeleccionarEnLista(string CodigoBarra)
        {
            bool bRetorno = false;

            for (int i = 0; i < chkBultos.Items.Count; i++)
            {
                if (chkBultos.Items[i].ToString().IndexOf(CodigoBarra) > 0)
                {
                    chkBultos.SetItemChecked(i, true);
                    bRetorno = true;
                }



            }
            return bRetorno;
        }

        private void btnSeleccionarTodo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkBultos.Items.Count; i++)
            {

                chkBultos.SetItemChecked(i, true);



            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkBultos.Items.Count; i++)
            {

                chkBultos.SetItemChecked(i, false);
            }

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            // ImportarBultos();
            if (MessageBox.Show("Seguro que quiere importar datos a su base de datos local", "Aviso", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            try
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "[Importando datos a servidor local ... Bultos]";
                lblMensaje.Refresh();
                ImportarBultos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando registros a base de datos local " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (sErrores.Length > 0)
            {
                MessageBox.Show("Datos cargados con  Errores"  , "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form oForm = new Form();
                TextBox oText = new TextBox();
                oText.Name ="txtError";
                oText.Multiline =true;
                oForm.Controls.Add(oText);
                oText.Dock = DockStyle.Fill;
                oText.Text = sErrores.ToString();
                oForm.StartPosition = FormStartPosition.CenterScreen;
                oForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Datos cargados con exito" , "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            

        }



        void ImportarBultos()
        {


            foreach (int i in chkBultos.CheckedIndices)
            {
                int BltNumeroLocal = 0;
                string sBltNumero;
                string sCodigoBarra;
                string bltGuiaHija;
                string bltCodigoBarra;
                string sOriGen;


                sBltNumero = chkBultos.Items[i].ToString().Substring(0, chkBultos.Items[i].ToString().IndexOf("|") - 1).TrimEnd();
                ds.Tables["bultos"].DefaultView.RowFilter = "BLT_NUMERO = " + sBltNumero;

                if (ds.Tables["bultos"].DefaultView[0].Row["BLT_CODIGO_BARRA"] == null)
                    bltCodigoBarra = "";
                else
                    bltCodigoBarra = ds.Tables["bultos"].DefaultView[0].Row["BLT_CODIGO_BARRA"].ToString();

                if (ds.Tables["bultos"].DefaultView[0].Row["BLT_GUIA_HIJA"] == null)
                    bltGuiaHija = "";
                else
                    bltGuiaHija = ds.Tables["bultos"].DefaultView[0].Row["BLT_GUIA_HIJA"].ToString();


                BltNumeroLocal = TraeBltNumeroLocal(Convert.ToInt32(sBltNumero), bltCodigoBarra, bltGuiaHija);


                if (BltNumeroLocal == 0)
                {

                    ds.Tables["bultos"].DefaultView.RowFilter = "BLT_NUMERO = " + sBltNumero;
                    try
                    {

                        if (InsertarDatos(ds.Tables["bultos"].DefaultView[0].Row))
                        {

                            BltNumeroLocal = TraeBltNumeroLocal(Convert.ToInt32(sBltNumero), bltCodigoBarra, bltGuiaHija);
                        }
                        else
                        {
                            continue;
                        }

                    }
                    catch (Exception ex)
                    {
                        // throw ex;

                        MessageBox.Show("Error Actualizando datos de bultos " + "\n" + "  Codigo Barra:" + ds.Tables["bultos"].DefaultView[0].Row["BLT_CODIGO_BARRA"].ToString() +
                                                        "\n" + "  Guia Hija:" + ds.Tables["bultos"].DefaultView[0].Row["BLT_GUIA_HIJA"].ToString() +
                                                        "\n" + " BltNumeroLocal: " + BltNumeroLocal + "\n" + ex.Message, "aviso", MessageBoxButtons.OK);


                        continue;
                    }

                }

                if (BltNumeroLocal == 0)
                {
                    MessageBox.Show("Error Actualizando datos de bultos " + "\n" + "  Codigo Barra:" + ds.Tables["bultos"].DefaultView[0].Row["BLT_CODIGO_BARRA"].ToString() +
                                                      "\n" + "  Guia Hija:" + ds.Tables["bultos"].DefaultView[0].Row["BLT_GUIA_HIJA"].ToString() +
                                                      "\n" + " BltNumeroLocal: " + BltNumeroLocal + "\n", "aviso", MessageBoxButtons.OK);


                    continue;

                }
                else
                {/* el Bulto ya existe
                */
                    var oEquivalencia = unitOfWork.EquivalenciaBultosRepository.Get(filter: s => s.BLT_NUMERO_LOCAL == BltNumeroLocal).FirstOrDefault();
                    try
                    {
                        InsertaContenido(oEquivalencia);
                        InsertaRemitente(oEquivalencia);
                        InsertaCargos(oEquivalencia);
                        InsertaUnidades(oEquivalencia);
                        ActualizarItbis(oEquivalencia);
                        unitOfWork.Save();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }


                }

                //Aqui importo las tablas relacionadas en a los bultos.

            }
        }



        int TraeBltNumeroLocal(int bltNumero, string bltcodigoBarra, string bltGuiaHija)
        {
            int iRetorno = 0;

            try
            {
                var sQry = unitOfWork.EquivalenciaBultosRepository.Get(filter: s => s.BLT_NUMERO_SDQ == bltNumero).FirstOrDefault();
                if (sQry != null)
                    iRetorno = sQry.BLT_NUMERO_LOCAL;

            }
            catch (Exception ex)
            {
                throw ex;
            }




            return iRetorno;
        }



        bool InsertarDatos(DataRow oRow)
        {
            decimal mLargo = 0;
            decimal mAncho = 0;
            decimal mAlto = 0;
            string sOrigen = "";
            bool bRetorno = false;

            BO.Models.Bultos oBultos = new BO.Models.Bultos();

            //oBultos.BLT_NUMERO = -1;

            oBultos.ALM_CODIGO = Parametros.ParametrosSucursal.CodigoAlmacen;
            oBultos.BLT_UBICACION = Parametros.ParametrosSucursal.Ubicacion;
            oBultos.SUC_ID = Parametros.ParametrosSucursal.IdSucursal;
            var oCliente = unitOfWork.ClientesRepository.ClienteIdFromEps(oRow["CTE_NUMERO_EPS"].ToString().TrimEnd());
            if (oCliente.Count() != 0)
                oBultos.CTE_ID = oCliente.FirstOrDefault().CTE_ID;
            else
            {
                oBultos.CTE_ID = 1;
                sErrores.AppendLine("Cliente no Existe: " + oRow["CTE_NUMERO_EPS"].ToString());
                return bRetorno;
            }





            //  oRow["PRO_CODIGO"]
            //    oRow["SUP_CODIGO"]
            //ORI_CODIGO
            /* */
            var oProd = unitOfWork.ProductosRepository.ProdIdFromCode(oRow["ORI_CODIGO"].ToString().TrimEnd(),
                                                                                oRow["SUP_CODIGO"].ToString().TrimEnd(),
                                                                                 oRow["PRO_CODIGO"].ToString().TrimEnd()).FirstOrDefault();

            oBultos.PROD_ID = oProd.PROD_ID;

            oBultos.MAN_MANIFIESTO = oRow["MAN_MANIFIESTO"].ToString();
            oBultos.BLT_GUIA_HIJA = oRow["BLT_GUIA_HIJA"].ToString();
            oBultos.BLT_CODIGO_BARRA = oRow["BLT_CODIGO_BARRA"].ToString();



            sOrigen = oRow["BLT_DESTINO"].ToString();

            if (sOrigen.TrimEnd() == "")
                sOrigen = "SDQ";


            var sQryDst = unitOfWork.OrigenRepository.Get(filter: s => s.ORI_CODIGO == sOrigen).FirstOrDefault();

            oBultos.DEST_ID = sQryDst.ORI_ID;

            oBultos.BLT_PIEZAS = Convert.ToInt32(oRow["BLT_PIEZAS"]);
            oBultos.BLT_PIEZAS_SUPLIDOR = Convert.ToInt32(oRow["BLT_PIEZAS_SUPLIDOR"]);
            oBultos.BLT_PESO = Convert.ToDecimal(oRow["BLT_PESO"]);
            oBultos.BLT_PESO_SUPLIDOR = Convert.ToDecimal(oRow["BLT_PESO_SUPLIDOR"]);
            oBultos.BLT_PESO_REAL = Convert.ToDecimal(oRow["BLT_PESO_REAL"]);


            oBultos.BLT_ESTADO_ID = 2;
            //revisar
            oBultos.BLT_BOLSA_SUPLIDOR = oRow["BLT_BOLSA_SUPLIDOR"].ToString().TrimEnd();
            //
            oBultos.BLT_RECEP_SUPLIDOR = Convert.ToDateTime(oRow["BLT_RECEP_SUPLIDOR"]);
            oBultos.BLT_DESPA_SUPLIDOR = oRow["BLT_DESPA_SUPLIDOR"].ToString() == "" ? DateTime.Now : Convert.ToDateTime(oRow["BLT_DESPA_SUPLIDOR"]);
            oBultos.BLT_FECHA_RECEPCION = DateTime.Now;
            oBultos.BLT_FECHA_ENTREGADO = DateTime.Now;
            oBultos.BLT_ENTREGAR = true;
            oBultos.BLT_VENTANILLA = 0;
            oBultos.USUARIO_ID = 1;
            oBultos.FECHA_MODIF = DateTime.Now;


            sOrigen = oRow["BLT_ORIGEN"].ToString();
            if (sOrigen.TrimEnd() == "")
                sOrigen = "MIA";

            oBultos.ORI_ID = unitOfWork.OrigenRepository.Get(filter: s => s.ORI_CODIGO == sOrigen).FirstOrDefault().ORI_ID;

            oBultos.BLT_TRACKING_NUMBER = oRow["BLT_TRACKING_NUMBER"].ToString().TrimEnd();

            oBultos.MAN_GUIA = oRow["MAN_GUIA"].ToString();

            oBultos.CON_CODIGO_ID = 7;

            oBultos.BLT_VALOR_FOB = Convert.ToDecimal(oRow["BLT_VALOR_FOB"]);

            oBultos.BLT_OBSERVACION = oRow["BLT_OBSERVACION"].ToString();

            oBultos.BLT_ALTO = 1;
            oBultos.BLT_ANCHO = 1;
            oBultos.BLT_LARGO = 1;
            oBultos.BLT_ABIERTO_ADUANA = false;
            oBultos.BLT_ADUANA = false;
            oBultos.BLT_VOLUMEN = 0;
            //
            oBultos.BLT_MANIFIESTO_SUCURSAL = "NA";
            oBultos.BLT_BOLSA_SUCURSAL = "NA";


            try
            {
                unitOfWork.BultosRepository.Insert(oBultos);

                BO.Models.EquivalenciaBultos oEquivalencia = new BO.Models.EquivalenciaBultos();


                unitOfWork.Save();

                oEquivalencia.BLT_NUMERO_LOCAL = oBultos.BLT_NUMERO;
                oEquivalencia.BLT_NUMERO_SDQ = Convert.ToInt32(oRow["BLT_NUMERO"].ToString());
                oEquivalencia.FECHA_CAMBIO = DateTime.Now;
                oEquivalencia.FECHA_INGREO = DateTime.Now;

                unitOfWork.EquivalenciaBultosRepository.Insert(oEquivalencia);

                unitOfWork.Save();
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
                    //MessageBox.Show("Existen los siguientes errores:" + s, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sErrores.AppendLine("Error: Bulto:" + oRow["BLT_NUMERO"].ToString() + s);
                }
                //throw;
            }
            catch (Exception ex)
            {
                sErrores.AppendLine("Error:  Bulto:" + oRow["BLT_NUMERO"].ToString() + " " + ex.Message.ToString());

                //throw ex;
                //MessageBox.Show("Error..>" + ex.Message.ToString());
            }

            return bRetorno;



        }


        void InsertaContenido(BO.Models.EquivalenciaBultos pEquivalencia)
        {
            ds.Tables["CONTENIDO_BULTOS"].DefaultView.RowFilter = "BLT_NUMERO = " + pEquivalencia.BLT_NUMERO_SDQ.ToString();

            DataView dv = ds.Tables["CONTENIDO_BULTOS"].DefaultView;

            if (dv.Count > 0)
            {
                var Bultos = unitOfWork.BultosRepository.GetByID(pEquivalencia.BLT_NUMERO_LOCAL);

                Bultos.CONTENIDO = dv[0]["COB_CONTENIDO"].ToString().TrimEnd();

                unitOfWork.BultosRepository.Update(Bultos);

                unitOfWork.Save();
            }


        }

        void InsertaRemitente(BO.Models.EquivalenciaBultos pEquivalencia)
        {
            ds.Tables["remitente_destinatario"].DefaultView.RowFilter = "BLT_NUMERO = " + pEquivalencia.BLT_NUMERO_SDQ.ToString();

            DataView dv = ds.Tables["remitente_destinatario"].DefaultView;

            //RDE_REMITENTE
            //RDE_DESTINATARIO

            if (dv.Count > 0)
            {
                var Bultos = unitOfWork.BultosRepository.GetByID(pEquivalencia.BLT_NUMERO_LOCAL);

                Bultos.REMITENTE = dv[0]["RDE_REMITENTE"].ToString().TrimEnd();
                Bultos.DESTINATARIO = dv[0]["RDE_DESTINATARIO"].ToString().TrimEnd();

                unitOfWork.BultosRepository.Update(Bultos);

                unitOfWork.Save();
            }


        }

        void InsertaUnidades(BO.Models.EquivalenciaBultos pEquivalencia)
        {

            BO.BO.CalculoTafiras oTar = new BO.BO.CalculoTafiras();

            oTar.CalcularUnidades(pEquivalencia.BLT_NUMERO_LOCAL);

        }

        void ActualizarItbis(BO.Models.EquivalenciaBultos pEquivalencia)
        {
            var vQryBultosValores = unitOfWork.BultosValoresRepository.Get(filter: s => s.BLT_NUMERO == pEquivalencia.BLT_NUMERO_LOCAL);

            decimal dMontoItebis = 0;


            var QrycargosProd = unitOfWork.CargosProductoRepository.Get(filter: s => s.Cargos.CAR_CODIGO == "999").FirstOrDefault();

            //No se le pone itbis
            if (unitOfWork.BultosRepository.Get(filter: s => s.BLT_NUMERO == pEquivalencia.BLT_NUMERO_LOCAL).FirstOrDefault().Clientes.CTE_TIPO_FISCAL == 45)
            {
                return;
            };

            if (QrycargosProd != null)
            {

                foreach (var sQry in vQryBultosValores)
                {
                    if (sQry.CargosProducto.Cargos.CAR_ITBIS == true && sQry.CargosProducto.Cargos.ITBIS > 0)
                    {
                        dMontoItebis += Math.Round((sQry.BVA_MONTO_LOCAL * sQry.CargosProducto.Cargos.ITBIS) / 100, 2);

                    }
                }



                if (dMontoItebis > 0)
                {
                    

                    AgenciaEF_BO.Models.BultosValores oBultosValores;

                    oBultosValores = unitOfWork.BultosValoresRepository.Get(filter: xy => xy.BLT_NUMERO == pEquivalencia.BLT_NUMERO_LOCAL && xy.CARGO_PROD_ID == QrycargosProd.CARGO_PROD_ID).FirstOrDefault();

                    if (oBultosValores == null)
                    {
                        oBultosValores = new BO.Models.BultosValores();

                        oBultosValores.BLT_NUMERO = pEquivalencia.BLT_NUMERO_LOCAL;
                        oBultosValores.BVA_MONTO = dMontoItebis;
                        oBultosValores.BVA_MONTO_APLICAR = dMontoItebis;
                        oBultosValores.BVA_MONTO_LOCAL = dMontoItebis;
                        oBultosValores.BVA_TASA = 18;
                        oBultosValores.CARGO_PROD_ID = QrycargosProd.CARGO_PROD_ID;
                        unitOfWork.BultosValoresRepository.Insert(oBultosValores);
                    }
                    else
                    {
                        oBultosValores.BVA_MONTO = dMontoItebis;
                        oBultosValores.BVA_MONTO_APLICAR = dMontoItebis;
                        oBultosValores.BVA_MONTO_LOCAL = dMontoItebis;
                        unitOfWork.BultosValoresRepository.Update(oBultosValores);

                    }

                    

                }
            }

           
                            



        }

        void InsertaCargos(BO.Models.EquivalenciaBultos pEquivalencia)
        {
            ds.Tables["BULTOS_VALORES"].DefaultView.RowFilter = "BLT_NUMERO = " + pEquivalencia.BLT_NUMERO_SDQ.ToString();

            DataView dv = ds.Tables["BULTOS_VALORES"].DefaultView;

            var vQryBultos = unitOfWork.BultosRepository.GetByID(pEquivalencia.BLT_NUMERO_LOCAL);

            BO.BO.CalculoTafiras oTar = new BO.BO.CalculoTafiras();

            //RDE_REMITENTE
            //RDE_DESTINATARIO

            for (int i = 0; i < dv.Count; i++)
            {
                string sCarCodigo = dv[i]["CAR_CODIGO"].ToString().TrimEnd();
                decimal dMontoAplicar = Convert.ToDecimal(dv[i]["BVA_MONTO"]);
                //filter: s => s.PROD_ID == iProductoId && s.Cargos.CAR_BASE_ID == 29 && s.Cargos.CAR_ESTADO == true 
                var sQueryCargos = unitOfWork.CargosProductoRepository.Get(filter: s => s.Cargos.CAR_CODIGO == sCarCodigo && s.Cargos.CAR_BASE_ID == 29 && s.PROD_ID == vQryBultos.PROD_ID && s.Cargos.CAR_ESTADO == true).FirstOrDefault();

                if (sQueryCargos != null)
                {
                    var vBultosValores = unitOfWork.BultosValoresRepository.Get(filter: s => s.BLT_NUMERO == pEquivalencia.BLT_NUMERO_LOCAL && s.CargosProducto.Cargos.CAR_CODIGO == sCarCodigo).FirstOrDefault();
                    if (vBultosValores != null)
                    {
                        unitOfWork.BultosValoresRepository.Delete(vBultosValores);
                    }

                    var cargosExits = unitOfWork.CargosProductoRepository.Get(filter: s => s.PROD_ID == vQryBultos.PROD_ID && s.Cargos.CAR_BASE_ID == 29 && s.Cargos.CAR_ESTADO == true
                                            && s.Cargos.CAR_CODIGO == sCarCodigo).FirstOrDefault(); /*tipo cargos*/


                    BO.Models.BultosValores oBultosVal = new BO.Models.BultosValores();

                    oBultosVal.BLT_NUMERO = vQryBultos.BLT_NUMERO;
                    oBultosVal.CARGO_PROD_ID = cargosExits.CARGO_PROD_ID;
                    oBultosVal.BVA_TASA = cargosExits.TasaCambio.FACTOR_CONV;
                    oBultosVal.BVA_MONTO = dMontoAplicar;

                    if (cargosExits.Cargos.CAR_DIRECTO_TABLA == "D")
                        oBultosVal.BVA_MONTO_APLICAR = dMontoAplicar;
                    else
                    {
                        oBultosVal.BVA_MONTO_APLICAR = oTar.BuscarMontoAplicar(cargosExits.CARGO_PROD_ID, dMontoAplicar, vQryBultos.CTE_ID);

                    }
                    if (oBultosVal.BVA_MONTO_APLICAR < cargosExits.Cargos.CAR_MINIMO_FACTURAR)
                    {
                        oBultosVal.BVA_MONTO_APLICAR = cargosExits.Cargos.CAR_MINIMO_FACTURAR;
                    }

                    if (cargosExits.Cargos.CAR_FIJO_MULTIPLICAR == "F")
                        oBultosVal.BVA_MONTO_LOCAL = oBultosVal.BVA_MONTO_APLICAR * cargosExits.TasaCambio.FACTOR_CONV;
                    else
                        oBultosVal.BVA_MONTO_LOCAL = dMontoAplicar * oBultosVal.BVA_MONTO_APLICAR * cargosExits.TasaCambio.FACTOR_CONV;


                    unitOfWork.BultosValoresRepository.Insert(oBultosVal);


                }






                unitOfWork.Save();
            }


        }




    }
}
