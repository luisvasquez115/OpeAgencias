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
using System.Globalization;
using System.Threading;


namespace OpeAgencia2.Facturacion
{
    public partial class ConsultaOperaciones : Form
    {
        public ConsultaOperaciones()
        {
            InitializeComponent();
        }


        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        private BO.Models.Clientes oCliente = new BO.Models.Clientes();

        private BO.DAL.dsDatos.EnviosDataTable oEnvio = new BO.DAL.dsDatos.EnviosDataTable();
        BO.DAL.dsDatos.BultosValoresCargosDataTable oUnidades = new BO.DAL.dsDatos.BultosValoresCargosDataTable();
        //
        //CultureInfo oInfo;
        

        private void ConsultaEnvios_Load(object sender, EventArgs e)
        {
            CargarCombos();
          //  oInfo =   Thread.CurrentThread.CurrentCulture;

        }


        void CargarCombos()
        {
            var sQryCounter = from p in unitOfWork.UsuarioSucursalRepository.Get(filter: s=>s.SUC_ID == Parametros.ParametrosSucursal.IdSucursal)
                           select new {Id = p.Usuarios.USUARIO_ID, Nombre = p.Usuarios.USER_NAME};


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

            DateTime dFechaIni;
            DateTime dFechaFin;

            dFechaIni = txtFecha.Value.Date;
            dFechaFin = txtFecha.Value.Date.AddDays(1);

            var sQuery = from p in unitOfWork.RecibosRepository.Get(filter: s => s.FECHA >= dFechaIni && s.FECHA < dFechaFin
                                   )
                         orderby p.FECHA descending
                         select new { Id = p.RECIBO_ID, p.COUNTER_ID, Tipo = p.Tipos.TIPO_CODIGO+" "+p.Tipos.TIPO_NOMBRE, p.Clientes.CTE_NUMERO_EPS,NCF= p.NUM_FISCAL,Importe= p.IMPORTE_TOTAL, Estado = p.Estados.ESTADO_NOMBRE };


            dgDatos.DataSource = sQuery.ToList();
            
                      
                  

        }

        private void dgDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void anularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnularRecibo();
        }

        void AnularRecibo()
        {
            int iReciboId = -1;

            iReciboId = Convert.ToInt32(dgDatos[0, dgDatos.CurrentCell.RowIndex].Value);

            var recibo = unitOfWork.RecibosRepository.GetByID(iReciboId);

            if (recibo != null)
            {//"0,0.00", CultureInfo.InvariantCulture
                if (MessageBox.Show("Desea anular el recibo por un monto de: " + recibo.IMPORTE_TOTAL.ToString("0,0.00", CultureInfo.InvariantCulture), "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (ProcesoAnulacion(iReciboId) == false)
                    {
                        MessageBox.Show("Error procesando anulación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        bool  ProcesoAnulacion(int iReciboId)
            {
                Boolean bRetorno = false;
                string sMensaje = "";

                BO.BO.Facturar oFact = new BO.BO.Facturar();

                bRetorno = oFact.ProcesarAnulacion(iReciboId, Parametros.Parametros.UsuarioId, ref sMensaje);

                if (bRetorno==false)
                {
                    MessageBox.Show(sMensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Anulación realizada exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //ImprimirFactura(oFact.FacturaGenerada);
                    ImprimirFactura oImpFact = new ImprimirFactura();
                    oImpFact.Imprimir(oFact.FacturaGenerada);


                    //LimpiarPantalla();
                }

                return bRetorno;
            }

        private void reImprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
