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
using ImpresoraFiscal;

namespace OpeAgencia2.Facturacion
{
    public partial class frmManejadorImpresora : Form
    {

        Printer oPrinter;
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

  
        public frmManejadorImpresora()
        {
            InitializeComponent();

            BO.Models.Terminal oTerm = new BO.Models.Terminal();

            oTerm = unitOfWork.TerminalRepository.GetByID(Parametros.ParametrosSucursal.TermFiscalId);

            oPrinter = new Printer(oTerm);
        }

        private void frmManejadorImpresora_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var response = oPrinter.Connect();
            LlenarDatosImpresora();
            ActualizarEstadoPuerto(response == (uint)PrinterResponses.Success);

        }

        void LlenarDatosImpresora()
        {
            txtModoOperacion.Text = oPrinter.GetCountryId();
            txtModeloImpresora.Text = oPrinter.GetPrintingMechanism();
            txtNombreImpresora.Text = oPrinter.GetPrintingMechanismName();
            lblPuerto.Text = oPrinter.GetPort();

        }

        public void ActualizarEstadoPuerto(bool conectado)
        {
            lblEstado.Text = conectado ?
                @"Puerto actualmente conectado" : @"Puerto actualmente desconectado";
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            var response = oPrinter.Disconnect();
            ActualizarEstadoPuerto(false);
            LimpiarCampos();
        }

        void LimpiarCampos()
        {
            txtModoOperacion.Text = "";
            txtModeloImpresora.Text = "";
            txtNombreImpresora.Text = "";
            lblPuerto.Text = "";
        }
    }
}
