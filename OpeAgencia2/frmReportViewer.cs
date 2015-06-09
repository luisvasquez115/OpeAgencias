using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace OpeAgencia2
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer()
        {
            InitializeComponent();
        }

         //LocalReport report;
         DataTable dt = new DataTable();
         string sReportPath = "";

         string sTitulo = "";
      
         public frmReportViewer(string psReportPath, DataTable pDt)
         {
             InitializeComponent();

             sReportPath = psReportPath;
             dt = pDt;
         }

         public frmReportViewer(string psReportPath, DataTable pDt, string psTitulo)
         {
             InitializeComponent();

             sReportPath = psReportPath;
             dt = pDt;
             sTitulo = psTitulo;
         }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {


            this.reportViewer1.LocalReport.ReportEmbeddedResource = sReportPath;

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Encabezado1", Parametros.ParametrosSucursal.EncabezadoFactura1));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Encabezado2", Parametros.ParametrosSucursal.EncabezadoFactura2));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Encabezado3", Parametros.ParametrosSucursal.EncabezadoFactura3));

            if (sTitulo!= "")
            {
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Titulo", sTitulo));
            }

            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            this.reportViewer1.LocalReport.Refresh();

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }


      
    }
}
