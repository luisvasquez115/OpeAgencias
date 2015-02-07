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

namespace OpeAgencia2.Clientes
{
    public partial class frmConsultaMercancia : Form
    {
        public frmConsultaMercancia()
        {
            InitializeComponent();
        }


        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();


        private void frmConsultaMercancia_Load(object sender, EventArgs e)
        {
            cmbEstado.SelectedIndex = 0;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
             

          
                var  oBultos = from p in unitOfWork.BultosRepository.GetByNumeroEPS(txtEPS.Text,txtGuiaMadre.Text,txtCodigoBarra.Text,txtTracking.Text,cmbEstado.SelectedIndex)
                                  select new {p.BLT_NUMERO,p.Clientes.CTE_NUMERO_EPS,p.MAN_GUIA, p.BLT_CODIGO_BARRA,p.BLT_TRACKING_NUMBER,
                                      p.Productos.PRO_CODIGO,p.BLT_PESO, p.BLT_PIEZAS, p.REMITENTE, p.DESTINATARIO, p.BLT_ESTADO_ID};


                
                dg.DataSource = oBultos.ToList();
                dg.Columns[0].Visible = false;
            

        }

        private void dg_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dg.RowCount ; i++)
            {
                if (dg.Rows[i].Cells[10].Value.ToString() == "1")
                {
                    dg.Rows[i].DefaultCellStyle.BackColor = Color.Red ;
                    dg.Rows[i].DefaultCellStyle.ForeColor  = Color.White;
                }
                if (dg.Rows[i].Cells[10].Value.ToString() == "2")
                {
                    dg.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    dg.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                if (dg.Rows[i].Cells[10].Value.ToString() == "6")
                {
                    dg.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
                    dg.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
                if (dg.Rows[i].Cells[10].Value.ToString() == "5")
                {
                    dg.Rows[i].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    dg.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int iBltNumero = -1;

            iBltNumero = Convert.ToInt32(dg.Rows[dg.CurrentRow.Index].Cells[0].Value);

            Operaciones.frmRecepcion oFrom = new Operaciones.frmRecepcion(iBltNumero);

            oFrom.ShowDialog();

        

        }

      

    
    
    }
}
