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
using System.Collections;

namespace OpeAgencia2.Facturacion
{
    public partial class frmFactMercancia : Form
    {
        public frmFactMercancia()
        {
            InitializeComponent();
        }

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        private BO.Models.Clientes oCliente = new BO.Models.Clientes();

        //
        BO.DAL.dsDatos.CorrespondenciaDataTable oTableCorr;

        private void frmFactMercancia_Load(object sender, EventArgs e)
        {
            
            CargarCorrespondencia();
            LimpiarPantalla();
        }

         void  CargarCorrespondencia()
        {

            oTableCorr = new BO.DAL.dsDatos.CorrespondenciaDataTable();
            dgCorr.DataSource = oTableCorr;
            dgCorr.Columns[0].Visible = false;
            dgCorr.Columns[3].Visible = false;
            

        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabCargos_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }


        void BuscarPaquetes(int iCteId)
        {

            var oBultos = from p in unitOfWork.VW_BultosValoresRepository.Get(filter: s => s.CTE_ID == iCteId && s.BLT_ESTADO_ID == 2)
                          select new
                          {
                              p.BLT_NUMERO,
                              p.BLT_CODIGO_BARRA,
                              p.CONTENIDO,
                              p.BLT_PESO,
                              p.BLT_TRACKING_NUMBER,
                              p.MONTO
                          };



            this.dgPaq.DataSource = oBultos.ToList();
            this.dgPaq.Columns[0].Visible = false;

        }

        void BuscarCliente()
        {

             oCliente = unitOfWork.ClientesRepository.Get(filter: s => s.CTE_NUMERO_EPS == txtEPS.Text  && s.CTE_SUC_ID == Parametros.Parametros.SucursalActual).FirstOrDefault();

            if (oCliente !=null)
            {
                lblNombres.Text = oCliente.CTE_NOMBRE + " " + oCliente.CTE_APELLIDO;
                dFechaVenc.Value = oCliente.CTE_FECHA_VENCIMIENTO;
                BuscarPaquetes(oCliente.CTE_ID);
                if (oCliente.CTE_CREDITO == true)
                {
                    cmbTipoFact.Enabled = true;
                }
                else
                {
                    cmbTipoFact.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("No existe EPS", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtEPS.Text = "";
                txtEPS.Focus();

                lblNombres.Text = "";
                dgPaq.DataSource = null;
                dgCorr.DataSource = null;
            }

        }

        private void txtEPS_Leave(object sender, EventArgs e)
        {
            if (txtEPS.Text !="")
                   BuscarCliente();
           
        }

        private void dgPaq_SelectionChanged(object sender, EventArgs e)
        {
            ActualizaTotal();
        }

        void ActualizaTotal()
        {
            int iPaq = 0;
            decimal dMonto = 0;

            for (int i = 0; i < dgPaq.Rows.Count; i++)
            {
                if (dgPaq.Rows[i].Selected == true)
                {
                    iPaq++;
                    dMonto += Convert.ToDecimal(dgPaq.Rows[i].Cells[5].Value);
                }
            }
            //
            for (int i = 0; i < this.dgCorr.Rows.Count; i++)
            {
               
                    iPaq++;
                    dMonto += Convert.ToDecimal(dgCorr.Rows[i].Cells[2].Value);
            }


            this.txtPaq.Text = iPaq.ToString();
            txtMontoTotal.Text = dMonto.ToString();
        }

        private void btnCorres_Click(object sender, EventArgs e)
        {
            frmCorrespond x = new frmCorrespond();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                //Agregar correspondecia.
               if ((x.Peso > 0) || (x.Piezas > 0))
               {
                   RegistraCorrespondencia(x.Peso, x.Piezas);
                   ActualizaTotal();
               }

            }
        }

        void RegistraCorrespondencia(decimal pdPeso, int piPiezas)
        {
            List<BO.Models.BultosValores> oBultosValores = new List<BO.Models.BultosValores>();

            DataRow dr = oTableCorr.NewRow();
            dr["Producto"] = Parametros.Parametros.NomProdCorrespondencia;
            dr["ProdId"] = Parametros.Parametros.ProdCorrespondencia;
            dr["Piezas"] = piPiezas;
            dr["Peso"] = pdPeso;
            dr["Monto"] = 0;

            BO.BO.CalculoTafiras oTar = new BO.BO.CalculoTafiras();

            oBultosValores = oTar.CalcularCorrespondencia(Parametros.Parametros.ProdCorrespondencia, pdPeso, piPiezas, oCliente.CTE_ID);

            foreach(BO.Models.BultosValores oVal in oBultosValores)
            {
                dr["Monto"] = Math.Round((decimal)dr["Monto"] + oVal.BVA_MONTO_LOCAL,2);
            }

            oTableCorr.Rows.Add(dr);
            
        }

        private void dgCorr_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ActualizaTotal();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();
        }

        void LimpiarPantalla()
        {
            oTableCorr.Rows.Clear();
            dgPaq.DataSource = null;
            txtEPS.Text = "";
            txtEPS.Focus();
            lblNombres.Text = "";
            txtMontoTotal.Text = "0";
            txtPaq.Text = "0";
            cmbTipoFact.SelectedIndex = 0;
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            ArrayList oBltNumeros  = new ArrayList();
            bool bCredito, bPagado=false;
            decimal dMontoEfectivo = 0;
            decimal dMontoOtros = 0;
            decimal dDevolucion = 0;
            BO.DAL.dsDatos.DatosPagoDataTable DatosPago = new BO.DAL.dsDatos.DatosPagoDataTable();

            if (cmbTipoFact.SelectedIndex == 1)
                bCredito = true;
            else
                bCredito = false;

            if (!bCredito)
            {
                frmDatosPago x = new frmDatosPago(Convert.ToDecimal(txtMontoTotal.Text));
                x.StartPosition = FormStartPosition.CenterParent;
                x.ShowDialog();
                dMontoEfectivo = x.MontoEfectivo;
                dMontoOtros = x.MontoOtros;
                dDevolucion = x.Devolucion;
                DatosPago = x.DatosPago;
                if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
                     bPagado = true;
            }
            else
            {
                bPagado = false;

            }

            if ((bCredito == true) || (bPagado == true))
            {
                if (bCredito)
                {
                //VALIDO  QUE EL CLIENTE TENGA BALANCE
                if (oCliente.CTE_BALANCE_DISPONIBLE - Convert.ToDecimal(txtMontoTotal.Text) < 0)
                {
                    MessageBox.Show("El balance disponible del cliente es de: " + oCliente.CTE_BALANCE_DISPONIBLE.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                }//Aqui tengo que ver si el cliente esta suspendido

                BultosAFacturar(ref oBltNumeros);
                BO.BO.Facturar oFact = new BO.BO.Facturar();
                if (oFact.CrearFactura(dMontoEfectivo, dMontoOtros, dDevolucion, DatosPago,
                                   oCliente.CTE_ID, oCliente.CTE_TIPO_FISCAL, Parametros.Parametros.SucursalActual,
                                   Parametros.Parametros.UsuarioId, oBltNumeros,
                                   oTableCorr, Convert.ToDecimal(txtMontoTotal.Text), bCredito))
                {//Todo anduvo bien. Entonces Imprimo y limpio la pantalla.

                    //ImprimirFactura(oFact.FacturaGenerada);
                    ImprimirFactura oImpFact = new ImprimirFactura();
                    oImpFact.Imprimir(oFact.FacturaGenerada);


                    LimpiarPantalla();
                }

            }
        }

        void BultosAFacturar(ref ArrayList pBtlNumeros)
        {
            for(int i= 0; i < dgPaq.RowCount; i++)
            {
                if (dgPaq.Rows[i].Selected == true)
                       pBtlNumeros.Add(dgPaq.Rows[i].Cells[0].Value);
            }

        }

       
    }
}
