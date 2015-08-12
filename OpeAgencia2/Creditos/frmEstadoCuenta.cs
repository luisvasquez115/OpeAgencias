﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BO = AgenciaEF_BO;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using clsUtils;



namespace OpeAgencia2.Creditos
{
    public partial class frmEstadoCuenta : Form
    {
        public frmEstadoCuenta()
        {
            InitializeComponent();
        }

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        private BO.Models.Clientes oCliente = new BO.Models.Clientes();

        private void frmEstadoCuenta_Load(object sender, EventArgs e)
        {

        }
        int iEpsDesdeId = -1;
        int iEpsHastaId = -1;

        private void txtEpsDesde_Leave(object sender, EventArgs e)
        {
            var eps = unitOfWork.ClientesRepository.Get(filter: xy => xy.CTE_NUMERO_EPS == txtEpsDesde.Text).FirstOrDefault();

            if (eps == null)
            {
                MessageBox.Show("Numero de eps no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                iEpsDesdeId = eps.CTE_ID;
                lblEps.Text = eps.CTE_NOMBRE.ToString() + " " + eps.CTE_APELLIDO.ToString();
            }
        }

        private void txtEpsHasta_Leave(object sender, EventArgs e)
        {
            var eps = unitOfWork.ClientesRepository.Get(filter: xy => xy.CTE_NUMERO_EPS == txtEpsDesde.Text).FirstOrDefault();

            if (eps == null)
            {
                MessageBox.Show("Numero de eps no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                iEpsHastaId = eps.CTE_ID;
                this.lblEpsHasta.Text = eps.CTE_NOMBRE.ToString() + " " + eps.CTE_APELLIDO.ToString();
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {

            // dsFacturaBindingSource.DataSource = CargarDataSet();
            DataSet dsFacturas = new DataSet();
            DataTable dt = new DataTable();
            dt = CargarDatos();
            dt.TableName = "EstadoCuenta";
           
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No hay estados para imprimir","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            dsFacturas.Tables.Add(dt);



            LocalReport report = new LocalReport();
            report.ReportPath = @".\Reportes\rEstadoCuenta1.rdlc";

            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            report.SetParameters(new ReportParameter("Fecha", DateTime.Now.ToShortDateString()));

            report.SetParameters(new ReportParameter("Hora", DateTime.Now.ToShortDateString()));

            //report.SetParameters(new ReportParameter("Sucursal", dt.Rows[0]["SUCURSAL"].ToString()));


            //report.SetParameters(new ReportParameter("Factura", dt.Rows[0]["REC_TIPO"].ToString() + "-" + dt.Rows[0]["REC_ID"].ToString()));

            report.SetParameters(new ReportParameter("Encabezado1", Parametros.ParametrosSucursal.EncabezadoFactura1));
            report.SetParameters(new ReportParameter("Encabezado2", Parametros.ParametrosSucursal.EncabezadoFactura2));
            report.SetParameters(new ReportParameter("Encabezado3", Parametros.ParametrosSucursal.EncabezadoFactura3));

            /*
              report.DataSources.Add(
                 new ReportDataSource("Sales", LoadSalesData()));
               -----
              */

            frmReportViewer x = new frmReportViewer(report);

            x.ShowDialog();

            //Export(report);
            //Print();
        }


        DataTable  CargarDatos()
        {
             BO.DAL.dsFactura.EstadoCuentaDataTable oTable = new BO.DAL.dsFactura.EstadoCuentaDataTable();

             var Recibos = from p in unitOfWork.RecibosRepository.Get(filter: xy => xy.CTE_ID >= iEpsDesdeId && xy.CTE_ID <= iEpsHastaId && xy.ESTADO_ID == 13)
                           orderby (p.CTE_ID)
                           select new { p.CTE_ID, p.ESTADO_ID, p.F_COBRO, p.F_VCTO, p.FECHA, p.IMPORTE_CTA, p.IMPORTE_TOTAL, p.RECIBO_ID, p.TIPO_REC_ID };
                       

            foreach(var Reg in Recibos)
            {
                var oClientes = unitOfWork.ClientesRepository.GetByID(Reg.CTE_ID);

                BO.DAL.dsFactura.EstadoCuentaRow oRow = oTable.NewEstadoCuentaRow();

                oRow.BALANCE = Reg.IMPORTE_TOTAL-Reg.IMPORTE_CTA;
                oRow.CTE_NUMERO_EPS =oClientes.CTE_NUMERO_EPS;
                oRow.CUENTACLI =oClientes.CTE_NUMERO_EPS.ToString() +"-"+ oClientes.CTE_NOMBRE +" "+ oClientes.CTE_APELLIDO;
                oRow.DESC  = "";
                oRow.DIAS = Reg.FECHA.Subtract(DateTime.Now.Date).Days;
                oRow.DIRECCION1 = oClientes.CTE_DIRECCION_CASA == null ? " " : oClientes.CTE_DIRECCION_CASA.ToString();
                oRow.DIRECCION2 = oClientes.CTE_DIRECCION_OFICINA == null ? " " : oClientes.CTE_DIRECCION_OFICINA.ToString();
                oRow.F_ULT_PAGO = DateTime.Now;   //Hay que buscar;
                oRow.FECHA_VENCE = Reg.F_VCTO;
                oRow.IMPORTE = Reg.IMPORTE_TOTAL;
                oRow.MONTO_ULT_PAGO = 0;
                oRow.PAGOS = Reg.IMPORTE_CTA;
                oRow.REC_FECHA = Reg.FECHA;
                oRow.REC_ID = Reg.RECIBO_ID;
                //
                 var  oTipoDoc = unitOfWork.TiposRepository.GetByID(Reg.TIPO_REC_ID);
                oRow.REC_TIPO = oTipoDoc.TIPO_CODIGO+"-"+Reg.RECIBO_ID.ToString() +"[" + oTipoDoc.TIPO_DESCR +"]";

                 if (oClientes.CTE_CEDULA == null)
                        oRow.RNC = oClientes.CTE_RNC;
                    else
                    {
                         if (oClientes.CTE_CEDULA.TrimEnd() == "")
                             oRow.RNC = oClientes.CTE_RNC;
                         else
                         {
                             oRow.RNC = oClientes.CTE_CEDULA;
                         }

                    }

                oTable.Rows.Add(oRow);

            }

            return oTable;

        }
    }
}