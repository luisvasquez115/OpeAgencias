using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BO = AgenciaEF_BO;

namespace OpeAgencia2.Facturacion
{
    public partial class ListadoFacturasFecha : Form
    {
        public ListadoFacturasFecha()
        {
            InitializeComponent();
        }

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }


        void GenerarReporte()
        {
            unitOfWork = new BO.DAL.UnitOfWork();

            DateTime dFechaIni;
            DateTime dFechaFin;

            dFechaIni = this.txtFechaDesde.Value.Date;
            dFechaFin = this.txtFechaHasta.Value.Date.AddDays(1);

                  

            var sQuery = from p in unitOfWork.RecibosRepository.Get(filter: s => s.FECHA >= dFechaIni && s.FECHA < dFechaFin )
                         orderby p.FECHA
                         select new { Fecha = p.FECHA, Cliente = p.Clientes.CTE_NUMERO_EPS.TrimEnd() + "-" + p.Clientes.CTE_NOMBRE.TrimEnd() + " " + p.Clientes.CTE_APELLIDO.TrimEnd() ,
                                      Factura = p.Tipos.TIPO_CODIGO + "-" + p.RECIBO_ID,
                                      MontoGrabado = p.IMPORTE_GRAVADO,
                                      MontoExcento = p.IMPORTE_TOTAL - p.IMPORTE_GRAVADO,
                                      MontoItebis = p.IMPORTE_ITEBIS,
                             p.ITBIS,MontoFact=p.IMPORTE_TOTAL,Usuario=p.USER_CREA,NCF=p.NUM_FISCAL };

            BO.DAL.dsReportes.FacturaFechaDataTable oTable = new BO.DAL.dsReportes.FacturaFechaDataTable();

            foreach (var oQuery in sQuery)
            {
                BO.DAL.dsReportes.FacturaFechaRow oFactRow = oTable.NewFacturaFechaRow();

                oFactRow.Fecha = oQuery.Fecha;
                oFactRow.Cliente = oQuery.Cliente;
                oFactRow.Factura = oQuery.Factura;
                oFactRow.Fecha = oQuery.Fecha;
                oFactRow.MontoGrabado = oQuery.MontoGrabado;
                oFactRow.MontoExcento = oQuery.MontoExcento;
                oFactRow.MontoFact = oQuery.MontoFact;
                oFactRow.Usuario = oQuery.Usuario;
                oFactRow.ITBIS = oQuery.MontoItebis;
                oFactRow.NCF = oQuery.NCF;


                oTable.Rows.Add(oFactRow);

            }

            oTable.TableName = "FacturaFecha";

            // string sPath = @".\Reportes\CuandreCaja.rdlc";
            string sPath = @".\Reportes\rReporteFacturacionFecha.rdlc";
            string sTitulo = "Listado de Facturas por Fecha (" + txtFechaDesde.Value.ToShortDateString() + " - " + txtFechaHasta.Value.ToShortDateString() +")";

            frmReportViewer x = new frmReportViewer(sPath, oTable, sTitulo);

            x.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
