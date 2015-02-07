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
    public partial class frmFacturar : Form
    {

        
        
        

        public frmFacturar()
        {
            InitializeComponent();
        }

        public frmFacturar(decimal pdMontoTotal)
        {
            InitializeComponent();
            dMontoTotal = pdMontoTotal;
        }

        BO.DAL.dsDatos.DatosPagoDataTable oTable = new BO.DAL.dsDatos.DatosPagoDataTable();

        public BO.DAL.dsDatos.DatosPagoDataTable DatosPago
        {
            get { return oTable; }
        }

        decimal dMontoEfectivo = 0;
        decimal dDevolucion = 0;
        decimal dMontoTotal = 0;
        decimal dMontoOtros = 0;


        public decimal MontoEfectivo
        {
            get { return dMontoEfectivo; }
        }

        public decimal Devolucion
        {
            get { return dDevolucion; }
        }

      

        public decimal MontoOtros
        {
            get { return dMontoOtros; }
        }

        public decimal dMontoPendiente { set; get; }

        int iFormaDePago;

        public int FormaPago
        {
            get { return iFormaDePago; }
           }

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        //using BO = AgenciaEF_BO;

        private void frmFacturar_Load(object sender, EventArgs e)
        {
            CargarCombo();
            txtTotal.DecimalValue = dMontoTotal;
            txtMontoPendiente.DecimalValue = dMontoTotal;
            
        }


        void CargarCombo()
        {

            var Productos = from p in unitOfWork.TiposRepository.GetByGroupCode("TPAGO")
                            select new { Id = p.TIPO_ID, Nombre = p.TIPO_CODIGO + "-->" + p.TIPO_NOMBRE };


            this.cmbFormaPago.DisplayMember = "Nombre";
            cmbFormaPago.ValueMember = "Id";

            this.cmbFormaPago.DataSource = Productos.ToList();

            cmbFormaPago.SelectedIndex = 0;

        }

        private void cmbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormaPago.SelectedIndex > 0)
            {
                frmDatosPago x = new frmDatosPago(dMontoTotal);
                x.StartPosition = FormStartPosition.CenterParent;
                x.ShowDialog();
                if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    txtOtros.DecimalValue = dMontoTotal;
                    
                    oTable = x.DatosPago;

                    btnAceptar.Enabled = true;
                   
                }
                txtEfectivo.IntValue = 0;
                dMontoPendiente = x.dMontoPend;
                if (x.dMontoPend > 0)
                    txtEfectivo.Enabled = true;
                else
                    txtEfectivo.Enabled = false;
              
                txtEfectivo.Enabled = false;
            }
            else
            {
                txtEfectivo.Enabled = true;
                txtOtros.IntValue = 0;
                dMontoOtros = 0;
            }
        }

        private void txtEfectivo_Load(object sender, EventArgs e)
        {

        }

        private void txtEfectivo_Leave(object sender, EventArgs e)
        {
            if (txtEfectivo.DecimalValue > dMontoPendiente)
            {
                dMontoPendiente = 0;
                txtMontoPendiente.DecimalValue = 0;
                txtDevolucion.DecimalValue = (txtEfectivo.DecimalValue - txtTotal.DecimalValue);
                btnAceptar.Enabled = true;
            }
            else if (txtEfectivo.DecimalValue == txtTotal.DecimalValue)
            {
                dMontoPendiente = 0;
                txtMontoPendiente.DecimalValue = 0;
                txtDevolucion.DecimalValue = 0;
                btnAceptar.Enabled = true;
            }
            else
            {
                txtEfectivo.IntValue = 0;
                txtEfectivo.Focus();
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            iFormaDePago = Convert.ToInt32(cmbFormaPago.SelectedValue);
            dMontoEfectivo = txtEfectivo.DecimalValue;
            dMontoOtros = txtOtros.DecimalValue;
            dDevolucion = txtDevolucion.DecimalValue;
        }
    }
}
