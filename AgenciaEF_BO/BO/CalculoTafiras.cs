using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaEF_BO.DAL;
using AgenciaEF_BO.Models;

namespace AgenciaEF_BO.BO
{
    public class CalculoTafiras
    {

        private UnitOfWork unitOfWork = new UnitOfWork();

        public decimal BuscarMontoAplicar(int piCargoId, decimal Monto, int iNumeroEPS)
        {
            decimal dRetorno = 1;

            var Clientes = unitOfWork.ClientesRepository.GetByID(iNumeroEPS);

            var cargosProd = from p in unitOfWork.CargosValoresRepository.Get(filter: s => s.COD_TAR_ID == Clientes.COD_TARIFA && s.SUC_ID == Clientes.CTE_SUC_ID && s.CARGO_PROD_ID == piCargoId)
                             orderby p.VAL_HASTA
                             select new { p.VAL_HASTA, p.VAL_PORCENTAJE, p.VAL_VALOR, p.VAL_ADICIONAL };


            foreach (var valor in cargosProd)
            {
                if (Monto <= valor.VAL_HASTA)
                {
                    dRetorno = valor.VAL_VALOR;
                    break;
                }


            }



            return dRetorno;

        }

        public void  CalcularUnidades(int bltNumero)
        {

            int iProductoId;
            decimal dPeso;
            decimal dValorFOB;
            decimal dSellos; 
            decimal dOverSize;
            int iNumeroEps;

            var vQryBultos = unitOfWork.BultosRepository.GetByID(bltNumero);

            iProductoId = vQryBultos.PROD_ID;
            dPeso = vQryBultos.BLT_PESO;
            dValorFOB = vQryBultos.BLT_VALOR_FOB;
            dSellos = vQryBultos.BLT_MONTO_SELLOS;

            dOverSize = vQryBultos.BLT_VOLUMEN;
            iNumeroEps = vQryBultos.CTE_ID;


            List<BultosValores> lBultosVal = new List<BultosValores>();

            var cargosExits = unitOfWork.CargosProductoRepository.Get(filter: s => s.PROD_ID == iProductoId && s.Cargos.CAR_BASE_ID == 25 && s.Cargos.CAR_ESTADO == true); /*tipo cargos*/

            // var cargosProd = unitOfWork.CargosProductoRepository.GetByID(iCargoProd);


            foreach (var cargo in cargosExits)
            {
                BultosValores oBultosVal = new BultosValores();

                oBultosVal.BLT_NUMERO = bltNumero;

                var OldBultosVal = unitOfWork.BultosValoresRepository.Get(filter: s => s.CARGO_PROD_ID == cargo.CARGO_PROD_ID && s.BLT_NUMERO == bltNumero).FirstOrDefault();

                if (OldBultosVal != null)
                {
                    unitOfWork.BultosValoresRepository.Delete(OldBultosVal);
                }



                oBultosVal.CARGO_PROD_ID = cargo.CARGO_PROD_ID;
                oBultosVal.BVA_TASA = cargo.TasaCambio.FACTOR_CONV;
                oBultosVal.BVA_MONTO = dPeso;
                oBultosVal.BVA_MONTO_APLICAR = BuscarMontoAplicar(cargo.CARGO_PROD_ID, dPeso, iNumeroEps);


                if (cargo.Cargos.CAR_FIJO_MULTIPLICAR == "F")
                {
                    if ((oBultosVal.BVA_MONTO_APLICAR) < cargo.Cargos.CAR_MINIMO_FACTURAR)
                    {
                        oBultosVal.BVA_MONTO_APLICAR = cargo.Cargos.CAR_MINIMO_FACTURAR;
                    }

                    oBultosVal.BVA_MONTO_LOCAL = oBultosVal.BVA_MONTO_APLICAR * cargo.TasaCambio.FACTOR_CONV;

                }
                else
                {
                    if (dPeso < cargo.Cargos.CAR_MINIMO_FACTURAR)
                    {
                        dPeso = Convert.ToDecimal(cargo.Cargos.CAR_MINIMO_FACTURAR);
                       
                    }

                    oBultosVal.BVA_MONTO_LOCAL = dPeso * oBultosVal.BVA_MONTO_APLICAR * cargo.TasaCambio.FACTOR_CONV;
                }

                unitOfWork.BultosValoresRepository.Insert(oBultosVal);

                lBultosVal.Add(oBultosVal);

                unitOfWork.Save();

            }

        
        }


        public List<BultosValores> CalcularCorrespondencia(int piProdId, decimal pdPeso, int piPiezas, int piNumeroEPS)
        {

            int iProductoId;
            decimal dPeso;
      
            int iNumeroEps;
            int iPiezas; 
          

            iProductoId = piProdId;
            dPeso = pdPeso;
            iPiezas = piPiezas;
            iNumeroEps = piNumeroEPS;


            List<BultosValores> lBultosVal = new List<BultosValores>();

            var cargosExits = unitOfWork.CargosProductoRepository.Get(filter: s => s.PROD_ID == iProductoId && s.Cargos.CAR_BASE_ID == 25 && s.Cargos.CAR_ESTADO == true); /*tipo cargos*/

            // var cargosProd = unitOfWork.CargosProductoRepository.GetByID(iCargoProd);


            foreach (var cargo in cargosExits)
            {
                BultosValores oBultosVal = new BultosValores();

                oBultosVal.CARGO_PROD_ID = cargo.CARGO_PROD_ID;
                oBultosVal.BVA_TASA = cargo.TasaCambio.FACTOR_CONV;
                oBultosVal.BVA_MONTO = dPeso;
                oBultosVal.BVA_MONTO_APLICAR = BuscarMontoAplicar(cargo.CARGO_PROD_ID, dPeso, iNumeroEps);


                if (cargo.Cargos.CAR_FIJO_MULTIPLICAR == "F")
                {
                    if ((oBultosVal.BVA_MONTO_APLICAR) < cargo.Cargos.CAR_MINIMO_FACTURAR)
                    {
                        oBultosVal.BVA_MONTO_APLICAR = cargo.Cargos.CAR_MINIMO_FACTURAR;
                    }

                    oBultosVal.BVA_MONTO_LOCAL = oBultosVal.BVA_MONTO_APLICAR * cargo.TasaCambio.FACTOR_CONV;

                }
                else
                {
                    if (dPeso < cargo.Producto.PRO_MINIMO)
                    {
                        dPeso = Convert.ToDecimal(cargo.Producto.PRO_MINIMO);

                    }

                    oBultosVal.BVA_MONTO_LOCAL = dPeso * oBultosVal.BVA_MONTO_APLICAR * cargo.TasaCambio.FACTOR_CONV;
                }

                //unitOfWork.BultosValoresRepository.Insert(oBultosVal);

                lBultosVal.Add(oBultosVal);

               

            }

            return lBultosVal;


        }


    }
}
