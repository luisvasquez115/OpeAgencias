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
    public partial class frmMovCaja : Form
    {
        public frmMovCaja()
        {
            InitializeComponent();
        }
  
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        private BO.Models.Clientes oCliente = new BO.Models.Clientes();

        private BO.DAL.dsDatos.EnviosDataTable oEnvio = new BO.DAL.dsDatos.EnviosDataTable();
        BO.DAL.dsDatos.BultosValoresCargosDataTable oUnidades = new BO.DAL.dsDatos.BultosValoresCargosDataTable();
        //
        //CultureInfo oInfo;


        private void frmMovCaja_Load(object sender, EventArgs e)
        {
            CargarCombos();
            //  oInfo =   Thread.CurrentThread.CurrentCulture;

        }


        void CargarCombos()
        {
            var sQryCounter = from p in unitOfWork.UsuarioSucursalRepository.Get(filter: s => s.SUC_ID == Parametros.ParametrosSucursal.IdSucursal)
                              select new { Id = p.Usuarios.USUARIO_ID, Nombre = p.Usuarios.USER_NAME };


            cmbCounter.ValueMember = "Id";
            cmbCounter.DisplayMember = "Nombre";

            cmbCounter.DataSource = sQryCounter.ToList();

            cmbCounter.SelectedValue = Parametros.Parametros.UsuarioId;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarDatos();
        }



        void BuscarDatos()
        {
            unitOfWork = new BO.DAL.UnitOfWork();

            DateTime dFechaIni;
            DateTime dFechaFin;

            dFechaIni = txtFecha.Value.Date;
            dFechaFin = txtFecha.Value.Date.AddDays(1);

            int iCounterId = -1;

            iCounterId = Convert.ToInt32(cmbCounter.SelectedValue);

            var sQuery = from p in unitOfWork.MovCajaRepository.Get(filter: s => s.FECHA >= dFechaIni && s.FECHA < dFechaFin && s.COUNTER_ID == iCounterId
                                     )
                             orderby p.FECHA descending
                             select new { Id = p.MOVCAJA_ID,   Fecha = p.FECHA,  p.COUNTER_ID, Tipo = p.Tipos.TIPO_CODIGO + " " + p.Tipos.TIPO_NOMBRE, p.Clientes.CTE_NUMERO_EPS, Importe = p.IMPORTE };


                dgDatos.DataSource = sQuery.ToList();



        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            unitOfWork = new BO.DAL.UnitOfWork();

            DateTime dFechaIni;
            DateTime dFechaFin;

            dFechaIni = txtFecha.Value.Date;
            dFechaFin = txtFecha.Value.Date.AddDays(1);

            int iCounterId = -1;

            iCounterId = Convert.ToInt32(cmbCounter.SelectedValue);

            var sQuery = from p in unitOfWork.MovCajaRepository.Get(filter: s => s.FECHA >= dFechaIni && s.FECHA < dFechaFin && s.COUNTER_ID == iCounterId
                                     )
                         orderby p.FECHA descending
                         select new { Id = p.MOVCAJA_ID, Fecha = p.FECHA, Counter =p.Usuarios.NOMBRES +" "+ p.Usuarios.APELLIDOS,Tipo = p.Tipos.TIPO_CODIGO ,Descr =  p.Tipos.TIPO_NOMBRE, p.Clientes.CTE_NUMERO_EPS, Importe = p.IMPORTE };

            BO.DAL.dsReportes.CuadreCajaDataTable oTable = new BO.DAL.dsReportes.CuadreCajaDataTable();

            foreach (var oQuery in sQuery)
            {
                BO.DAL.dsReportes.CuadreCajaRow oFactRow = oTable.NewCuadreCajaRow();

                oFactRow.Descr = oQuery.Descr;
                oFactRow.EPS = oQuery.CTE_NUMERO_EPS;
                oFactRow.Tipo = oQuery.Tipo;
                oFactRow.Fecha = oQuery.Fecha;
                oFactRow.Id = oQuery.Id;
                oFactRow.Importe = oQuery.Importe;
                oFactRow.Counter = oQuery.Counter.ToString();

                oTable.Rows.Add(oFactRow);

            }

            oTable.TableName = "CuadreCaja";
      
           // string sPath = @".\Reportes\CuandreCaja.rdlc";
            string sPath = "OpeAgencia2.Reportes.CuandreCaja.rdlc";

            frmReportViewer x = new frmReportViewer(sPath,oTable);

            x.ShowDialog();

        }
    }
}
