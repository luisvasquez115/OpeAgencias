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


namespace OpeAgencia2.Operaciones
{
    public partial class frmRecepcion : Form
    {
        public frmRecepcion()
        {
            InitializeComponent();
        }

        public frmRecepcion(int piBltNumero)
        {
            InitializeComponent();
            _Id = piBltNumero;
            grbNavegacion.Visible = false;
        }

        int _Id = -1;
        int iNumeroEPS = -1;
        int iSucursalId =-1;
        BO.DAL.dsDatos.BultosValoresCargosDataTable oCargos = new BO.DAL.dsDatos.BultosValoresCargosDataTable();
        BO.DAL.dsDatos.BultosValoresCargosDataTable oUnidades = new BO.DAL.dsDatos.BultosValoresCargosDataTable();
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        //using BO = AgenciaEF_BO;
    
        
        private void frmRecepcion_Load(object sender, EventArgs e)
        {
            CombosProductos();
            CombosEstados();
            this.txtCodigoBarra.Focus();
            if (_Id != -1)
            {
                var Bultos = unitOfWork.BultosRepository.GetByID(_Id);
                txtCodigoBarra.Text = Bultos.BLT_CODIGO_BARRA;
                BuscarDatosPorCodigoBarra();
            }

        }


        #region "Combos"

        void CombosProductos()
        {
            var Productos = from p in unitOfWork.ProductosRepository.Get(filter:xy=>xy.Tipos.TIPO_CODIGO=="R")
                            select new { Id = p.PROD_ID, Nombre = p.PRO_CODIGO + "-->" + p.PRO_DESCRIPCION };


            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Id";

            this.cmbProducto.DataSource = Productos.ToList();
        }

        void CombosEstados()
        {
            var Estados = from p in unitOfWork.EstadosRepository.GetByGroupCode("CP")
                            select new { Id = p.ESTADO_ID, Nombre = p.ESTADO_NOMBRE + "-->" + p.ESTADO_DESCR };


            cmbCondicion.DisplayMember = "Nombre";
            cmbCondicion.ValueMember = "Id";

            this.cmbCondicion.DataSource = Estados.ToList();
        }

        void ComboCargos(int iProductoId)
        {
          
            var cargosExits = from p in unitOfWork.CargosProductoRepository.Get(filter: s => s.PROD_ID == iProductoId && s.Cargos.CAR_BASE_ID == 29 && s.Cargos.CAR_ESTADO == true ) /*tipo cargos*/
                              select new { Id = p.CARGO_PROD_ID, Nombre = p.Cargos.CAR_CODIGO +"-->" + p.Cargos.CAR_DESCRIPCION + "("+p.TasaCambio.TASA_CODIGO + ")"};

          
            //
            this.cmbCargos.ValueMember = "Id";
            cmbCargos.DisplayMember = "Nombre";
            //





            cmbCargos.DataSource = cargosExits.ToList();
           



            cmbCargos.SelectedValue = -1;
        }



        #endregion

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Realizar validaciones
            CarcularUnidades();
            InsertarBulto();
        }

        void InsertarBulto()
        {

            BO.Models.Bultos oBulto = new BO.Models.Bultos();

            if (_Id !=-1)
            {
                oBulto = unitOfWork.BultosRepository.GetByID(_Id);
            }

            oBulto.BLT_ABIERTO_ADUANA = chkAbiertoAduanas.Checked;
            oBulto.ALM_CODIGO = 1;
            oBulto.BLT_ADUANA = false;
            oBulto.BLT_ALTO = -1;
            oBulto.BLT_ANCHO = -1;
            oBulto.BLT_BOLSA_SUCURSAL = "NA";
            oBulto.BLT_BOLSA_SUPLIDOR = "NA";
            oBulto.BLT_CODIGO_BARRA = txtCodigoBarra.Text;
            oBulto.BLT_DESPA_SUPLIDOR = DateTime.Now;
            oBulto.BLT_ENTREGAR = false;
            oBulto.BLT_ESTADO_ID = 2;
            oBulto.BLT_FECHA_ENTREGADO = DateTime.Now;
            oBulto.BLT_FECHA_RECEPCION = DateTime.Now;
            oBulto.BLT_GUIA_HIJA = txtCodigoBarra.Text;
            oBulto.BLT_HORA_ENTREGADO = "";
            oBulto.BLT_HORA_RECIBIDO = DateTime.Now.Hour.ToString();
            oBulto.BLT_LARGO = -1;
            oBulto.BLT_LIQUIDADOR = "NA";
            oBulto.BLT_MANIFIESTO_SUCURSAL = "NA";
            oBulto.BLT_MONTO_SELLOS = 0;
            oBulto.BLT_OBSERVACION = "NA";
            oBulto.BLT_PESO = Convert.ToDecimal(txtPeso.Text);
            oBulto.BLT_PESO_REAL = Convert.ToDecimal(txtPeso.Text);
            oBulto.BLT_PESO_SUPLIDOR = Convert.ToDecimal(txtPeso.Text);
            oBulto.BLT_PIEZAS = Convert.ToInt32(txtPiezas.Value);
            oBulto.BLT_PIEZAS_SUPLIDOR = Convert.ToInt32(txtPiezas.Value);
            oBulto.BLT_PONUMBER = "NA";
            oBulto.BLT_PORCIENTO_SELLO = 0;
            oBulto.BLT_RECEP_SUPLIDOR = DateTime.Now;
            oBulto.BLT_TRACKING_NUMBER = "NA";
            oBulto.BLT_UBICACION = "NA";
            oBulto.BLT_VALOR_FOB = Convert.ToDecimal(txtValorFOB.Text);
            oBulto.BLT_VENTANILLA = -1;
            oBulto.BLT_VOLUMEN = 0;
            oBulto.BLT_WAREHOUSE = "NA";
            oBulto.CON_CODIGO_ID = Convert.ToInt32(cmbCondicion.SelectedValue);
            oBulto.CONTENIDO = txtContenido.Text;
            oBulto.CTE_ID = iNumeroEPS;
            oBulto.SUC_ID = iSucursalId;
            oBulto.DEST_ID = 168;  /*SDQ*/
            oBulto.DESTINATARIO = txtConsignatario.Text;
            oBulto.FECHA_MODIF = DateTime.Now;
            oBulto.MAN_GUIA = "NA";
            oBulto.MAN_MANIFIESTO = "NA";
            oBulto.ORI_ID = 130;
            oBulto.PROD_ID = Convert.ToInt32(cmbProducto.SelectedValue);
            oBulto.REMITENTE = txtRemitente.Text;
            oBulto.UBI_CODIGO = "NA";
            oBulto.USUARIO_ID = Parametros.Parametros.UsuarioId;
            

            try
            {

                if (_Id < 0)
                {
                    unitOfWork.BultosRepository.Insert(oBulto);
                }
                else
                {
                    unitOfWork.BultosRepository.Update(oBulto);
                }

                SalvarDetalle(oBulto.BLT_NUMERO);

                unitOfWork.Save();
                ActualizarItbis(oBulto.BLT_NUMERO);
                unitOfWork.Save();
                
                MessageBox.Show("Datos salvados satisfactoriamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                txtCodigoBarra.Text = "";

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    string s = "";
                    /*
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    */


                    foreach (var ve in eve.ValidationErrors)
                    {
                        s += ve.ErrorMessage + "\n";
                        /*Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);*/
                    }
                    MessageBox.Show("Existen los siguientes errores:" + s, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    unitOfWork.Dispose();
                }
                //throw;
            }
            catch (Exception ex)
            {
                unitOfWork.Dispose();
                throw ex;
            }



        }

        /// <summary>
        /// Actualizar los datos del itbis
        /// </summary>
        /// <param name="pEquivalencia"></param>

        void ActualizarItbis(int piBltNumero)
        {
            var vQryBultosValores = unitOfWork.BultosValoresRepository.Get(filter: s => s.BLT_NUMERO == piBltNumero);

            decimal dMontoItebis = 0;


            var QrycargosProd = unitOfWork.CargosProductoRepository.Get(filter: s => s.Cargos.CAR_CODIGO == "999").FirstOrDefault();

            if (QrycargosProd != null)
            {

                foreach (var sQry in vQryBultosValores)
                {
                    if (sQry.CargosProducto.Cargos.CAR_ITBIS == true && sQry.CargosProducto.Cargos.ITBIS > 0)
                    {
                        dMontoItebis += Math.Round((sQry.BVA_MONTO_LOCAL * sQry.CargosProducto.Cargos.ITBIS) / 100, 2);

                    }
                }

                if (dMontoItebis > 0)
                {


                    AgenciaEF_BO.Models.BultosValores oBultosValores;

                    oBultosValores = unitOfWork.BultosValoresRepository.Get(filter: xy => xy.BLT_NUMERO == piBltNumero && xy.CARGO_PROD_ID == QrycargosProd.CARGO_PROD_ID).FirstOrDefault();

                    if (oBultosValores == null)
                    {
                        oBultosValores = new BO.Models.BultosValores();

                        oBultosValores.BLT_NUMERO = piBltNumero;
                        oBultosValores.BVA_MONTO = dMontoItebis;
                        oBultosValores.BVA_MONTO_APLICAR = dMontoItebis;
                        oBultosValores.BVA_MONTO_LOCAL = dMontoItebis;
                        oBultosValores.BVA_TASA = 18;
                        oBultosValores.CARGO_PROD_ID = QrycargosProd.CARGO_PROD_ID;
                        unitOfWork.BultosValoresRepository.Insert(oBultosValores);
                    }
                    else
                    {
                        oBultosValores.BVA_MONTO = dMontoItebis;
                        oBultosValores.BVA_MONTO_APLICAR = dMontoItebis;
                        oBultosValores.BVA_MONTO_LOCAL = dMontoItebis;
                        unitOfWork.BultosValoresRepository.Update(oBultosValores);

                    }



                }
            }
        }

         
        private void SalvarDetalle(int bltNumero)
        {
            var oBultosValores = unitOfWork.BultosValoresRepository.Get(filter: s => s.BLT_NUMERO == bltNumero);

            foreach(var oReg in oBultosValores)
            {
                unitOfWork.BultosValoresRepository.Delete(oReg.BVA_ID);
            }
            foreach(DataRow dr in oUnidades)
            {
                BO.Models.BultosValores oNewValores = new BO.Models.BultosValores();
                oNewValores.BLT_NUMERO = bltNumero;
                oNewValores.BVA_MONTO = Convert.ToDecimal(dr["Monto"]);
                oNewValores.BVA_MONTO_APLICAR = Convert.ToDecimal(dr["MontoAplicar"]);
                oNewValores.BVA_MONTO_LOCAL = Convert.ToDecimal(dr["MontoLocal"]);
                oNewValores.BVA_TASA = Convert.ToDecimal(dr["Tasa"]);
                oNewValores.CARGO_PROD_ID = Convert.ToInt32(dr["CARGO_PROD_ID"]);
                unitOfWork.BultosValoresRepository.Insert(oNewValores);
            }

            foreach (DataRow dr in oCargos)
            {
                BO.Models.BultosValores oNewValores = new BO.Models.BultosValores();
                oNewValores.BLT_NUMERO = bltNumero;
                oNewValores.BVA_MONTO = Convert.ToDecimal(dr["Monto"]);
                oNewValores.BVA_MONTO_APLICAR = Convert.ToDecimal(dr["MontoAplicar"]);
                oNewValores.BVA_MONTO_LOCAL = Convert.ToDecimal(dr["MontoLocal"]);
                oNewValores.BVA_TASA = Convert.ToDecimal(dr["Tasa"]);
                oNewValores.CARGO_PROD_ID = Convert.ToInt32(dr["CARGO_PROD_ID"]);
                unitOfWork.BultosValoresRepository.Insert(oNewValores);
            }


        }

        private void txtNumeroEPS_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtNumeroEPS_Leave(object sender, EventArgs e)
        {
            var Eps = unitOfWork.ClientesRepository.Get(filter: s => s.CTE_NUMERO_EPS == txtNumeroEPS.Text).FirstOrDefault();

            if (Eps != null)
            {
                lblEps.Text = Eps.CTE_NOMBRE.ToString() + " " + Eps.CTE_APELLIDO;
                iNumeroEPS = Eps.CTE_ID;
                iSucursalId = Eps.CTE_SUC_ID;
            }
            else
            {
                lblEps.Text = "";
                iNumeroEPS = -1;
                iSucursalId = -1;
            }

        }

        private void txtCodigoBarra_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigoBarra_Leave(object sender, EventArgs e)
        {
            BuscarDatosPorCodigoBarra();
        }

        void BuscarDatosPorCodigoBarra()
        {
            if (txtCodigoBarra.Text == "")
                txtCodigoBarra.Focus();
            else
            {
                //
                var sqlBultos = unitOfWork.BultosRepository.Get(filter: s => s.BLT_CODIGO_BARRA == txtCodigoBarra.Text).FirstOrDefault();

                if (sqlBultos != null)
                {
                    _Id = sqlBultos.BLT_NUMERO;
                    BuscarDatos(sqlBultos);
                }
                else
                {
                    LimpiarCampos();
                }
                this.txtCodigoBarra.Enabled = false;
                BuscarCargos();
                BuscarUnidades();
            }
        }

        void BuscarDatos(BO.Models.Bultos pBultos)
        {

            BO.Models.Bultos oBulto = new BO.Models.Bultos();

            if (_Id != -1)
            {
                oBulto = unitOfWork.BultosRepository.GetByID(_Id);
            }

            chkAbiertoAduanas.Checked = oBulto.BLT_ABIERTO_ADUANA;
            //oBulto.ALM_CODIGO = 1;
            //oBulto.BLT_ADUANA = false;
            //oBulto.BLT_ALTO = -1;
            //oBulto.BLT_ANCHO = -1;
            //oBulto.BLT_BOLSA_SUCURSAL = "NA";
            //oBulto.BLT_BOLSA_SUPLIDOR = "NA";
            //txtCodigoBarra.Text =oBulto.BLT_CODIGO_BARRA;
            //oBulto.BLT_DESPA_SUPLIDOR = DateTime.Now;
            //oBulto.BLT_ENTREGAR = false;
            //oBulto.BLT_ESTADO_ID = 1;
            //oBulto.BLT_FECHA_ENTREGADO = DateTime.Now;
            //oBulto.BLT_FECHA_RECEPCION = DateTime.Now;
            //oBulto.BLT_GUIA_HIJA = txtCodigoBarra.Text;
            //oBulto.BLT_HORA_ENTREGADO = "";
            //oBulto.BLT_HORA_RECIBIDO = DateTime.Now.Hour.ToString();
            //oBulto.BLT_LARGO = -1;
            //oBulto.BLT_LIQUIDADOR = "NA";
            //oBulto.BLT_MANIFIESTO_SUCURSAL = "NA";
            //oBulto.BLT_MONTO_SELLOS = 0;
            //oBulto.BLT_OBSERVACION = "NA";
            txtPeso.Text = oBulto.BLT_PESO_REAL.ToString();
            
            //txtPeso.Text  oBulto.BLT_PESO_REAL.ToString();
            //oBulto.BLT_PESO_SUPLIDOR = Convert.ToDecimal(txtPeso.Text);
            txtPiezas.Value = oBulto.BLT_PIEZAS;
            //oBulto.BLT_PIEZAS_SUPLIDOR = Convert.ToInt32(txtPiezas.Value);
            //oBulto.BLT_PONUMBER = "NA";
            //oBulto.BLT_PORCIENTO_SELLO = 0;
            //oBulto.BLT_RECEP_SUPLIDOR = DateTime.Now;
            //oBulto.BLT_TRACKING_NUMBER = "NA";
            //oBulto.BLT_UBICACION = "NA";
            txtValorFOB.Text = oBulto.BLT_VALOR_FOB.ToString();
            //oBulto.BLT_VENTANILLA = -1;
            //oBulto.BLT_VOLUMEN = 0;
            //oBulto.BLT_WAREHOUSE = "NA";
            cmbCondicion.SelectedValue = oBulto.CON_CODIGO_ID;
            txtContenido.Text = oBulto.CONTENIDO;
            
            //oBulto.DEST_ID = 168;  /*SDQ*/
            txtConsignatario.Text = oBulto.DESTINATARIO;
            //oBulto.FECHA_MODIF = DateTime.Now;
            //oBulto.MAN_GUIA = "NA";
            //oBulto.MAN_MANIFIESTO = "NA";
            //oBulto.ORI_ID = 130;
            //oBulto.PRO_ID = Convert.ToInt32(cmbProducto.SelectedValue);
            txtRemitente.Text = oBulto.REMITENTE;
            //oBulto.UBI_CODIGO = "NA";
            //Bulto.USUARIO_ID = 1; /* Usuarios */

            iNumeroEPS = oBulto.CTE_ID;
            iSucursalId = oBulto.SUC_ID;

            var Clientes = unitOfWork.ClientesRepository.GetByID(iNumeroEPS);

            txtNumeroEPS.Text = Clientes.CTE_NUMERO_EPS.ToString();
            lblEps.Text = Clientes.CTE_NOMBRE + " " + Clientes.CTE_APELLIDO;


        }

        void BuscarCargos()
        {

            var qryCargos = from p in unitOfWork.BultosValoresRepository.Get(filter: s => s.BLT_NUMERO == _Id && s.CargosProducto.Cargos.CAR_BASE_ID == 29)
                            select new { p.BVA_ID, p.CARGO_PROD_ID, Desc = p.CargosProducto.Cargos.CAR_CODIGO + "-->" + p.CargosProducto.Cargos.CAR_DESCRIPCION + "(" + p.CargosProducto.TasaCambio.TASA_CODIGO + ")",
                                         Monto = p.BVA_MONTO,
                                         Tasa = p.BVA_TASA,
                                         MontoLocal = p.BVA_MONTO_LOCAL,
                                         MontoAplicar = p.BVA_MONTO_APLICAR
                            };


            oCargos.Rows.Clear();

              foreach (var cargo in qryCargos)
            {
                DataRow dr = oCargos.NewRow();
                dr["ID"] = cargo.BVA_ID;
                dr["CARGO_PROD_ID"] = cargo.CARGO_PROD_ID;
                dr["Desc"] = cargo.Desc;
                dr["Tasa"] = cargo.Tasa;
                dr["Monto"] = cargo.Monto;
                dr["MontoLocal"] = cargo.MontoLocal;
                dr["MontoAplicar"] = cargo.MontoAplicar;

                oCargos.Rows.Add(dr);


            }

            dgCargos.DataSource = oCargos;
            dgCargos.Columns[0].Visible = false;
            dgCargos.Columns[1].Visible = false;

            dgCargos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        void BuscarUnidades()
        {

            var qryCargos = from p in unitOfWork.BultosValoresRepository.Get(filter: s => s.BLT_NUMERO == _Id && (s.CargosProducto.Cargos.CAR_BASE_ID == 25 || s.CargosProducto.Cargos.CAR_BASE_ID == 52 ))
                            select new
                            {
                                p.BVA_ID,
                                p.CARGO_PROD_ID,
                                Desc = p.CargosProducto.Cargos.CAR_CODIGO + "-->" + p.CargosProducto.Cargos.CAR_DESCRIPCION + "(" + p.CargosProducto.TasaCambio.TASA_CODIGO + ")",
                                Monto = p.BVA_MONTO,
                                Tasa = p.BVA_TASA,
                                MontoLocal = p.BVA_MONTO_LOCAL,
                                MontoAplicar = p.BVA_MONTO_APLICAR
                            };


            oUnidades.Rows.Clear();

            foreach (var cargo in qryCargos)
            {
                DataRow dr = oUnidades.NewRow();
                dr["ID"] = cargo.BVA_ID;
                dr["CARGO_PROD_ID"] = cargo.CARGO_PROD_ID;
                dr["Desc"] = cargo.Desc;
                dr["Tasa"] = cargo.Tasa;
                dr["Monto"] = cargo.Monto;
                dr["MontoLocal"] = cargo.MontoLocal;
                dr["MontoAplicar"] = cargo.MontoAplicar;

                oUnidades.Rows.Add(dr);


            }

            dgUnidades.DataSource = oUnidades;
            dgUnidades.Columns[0].Visible = false;
            dgUnidades.Columns[1].Visible = false;

            dgUnidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        void LimpiarCampos()
        {


            chkAbiertoAduanas.Checked = false;

         

            txtPeso.Text = "";


            txtPiezas.Value = 0;

            txtValorFOB.Text = "0";

            cmbCondicion.SelectedValue = -1;
            txtContenido.Text = "";

            //oBulto.DEST_ID = 168;  /*SDQ*/
            txtConsignatario.Text = "";

            txtRemitente.Text = "";


            iNumeroEPS = -1;

         

            txtNumeroEPS.Text = "";
           
  
        }

        private void txtCodigoBarra_Validating(object sender, CancelEventArgs e)
        {
            if (txtCodigoBarra.Text == "")
            {
                errorProvider1.SetError(txtCodigoBarra, "Este capo no puede quedar en blanco");
                e.Cancel = true;

            }
            else
            {
                errorProvider1.SetError(txtCodigoBarra, "");
                e.Cancel = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            this.txtCodigoBarra.Enabled = true;
            
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iProductoId = Convert.ToInt32(cmbProducto.SelectedValue);
            ComboCargos(iProductoId);
        }

        private void cmbCargos_TextChanged(object sender, EventArgs e)
        {
            
            cmbCargos.FindString(cmbCargos.Text);
            
        }

        private void cmbCargos_Enter(object sender, EventArgs e)
        {
            cmbCargos.DroppedDown = true;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //Agregar cargos
        private void btnCargoAdd_Click(object sender, EventArgs e)
        {

            if (iNumeroEPS == -1)
            {
                MessageBox.Show("Es necesario registra un numero de eps", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            int iCargoProd = -1;
            /* select new { p.ID, p.CARGO_PROD_ID, Desc = p.CargosProducto.Cargos.CAR_CODIGO + "-->" + p.CargosProducto.Cargos.CAR_DESCRIPCION + "(" + p.CargosProducto.TasaCambio.TASA_CODIGO + ")",
                            Monto = p.BVA_MONTO, Tasa= p.BVA_TASA, MontoLocal = p.BVA_MONTO_LOCAL };*/

            iCargoProd = Convert.ToInt32(cmbCargos.SelectedValue);

            var cargosProd = unitOfWork.CargosProductoRepository.GetByID(iCargoProd);

            DataRow dr = oCargos.NewRow();
            dr["ID"] = -1;
            dr["CARGO_PROD_ID"] = iCargoProd;
            dr["Desc"] = cmbCargos.Text;
            dr["Tasa"] = cargosProd.TasaCambio.FACTOR_CONV;
            dr["Monto"] = Convert.ToDecimal(txtMonto.Text);
            if (cargosProd.Cargos.CAR_DIRECTO_TABLA == "D")
                dr["MontoAplicar"] = Convert.ToDecimal(txtMonto.Text);
            else
            {
                dr["MontoAplicar"] = BuscarMontoAplicar(iCargoProd,Convert.ToDecimal(txtMonto.Text));

            }

            if (Convert.ToDecimal(dr["MontoAplicar"]) < Convert.ToDecimal(cargosProd.Cargos.CAR_MINIMO_FACTURAR))
            {
                Convert.ToDecimal(dr["MontoAplicar"] = Convert.ToDecimal(cargosProd.Cargos.CAR_MINIMO_FACTURAR));
            }

            if (cargosProd.Cargos.CAR_FIJO_MULTIPLICAR == "F")
                dr["MontoLocal"] = Convert.ToInt32(dr["MontoAplicar"]) * cargosProd.TasaCambio.FACTOR_CONV;
            else
                dr["MontoLocal"] = Convert.ToInt32(txtMonto.Text) * Convert.ToInt32(dr["MontoAplicar"]) * cargosProd.TasaCambio.FACTOR_CONV;


            oCargos.Rows.Add(dr);
            cmbCargos.SelectedValue = -1;
            txtMonto.Text = "";
            cmbCargos.Focus();


        }

        decimal  BuscarMontoAplicar(int piCargoId, decimal Monto)
        {
            decimal dRetorno = 1;

            var Clientes = unitOfWork.ClientesRepository.GetByID(iNumeroEPS);

            var cargosProd = from p in unitOfWork.CargosValoresRepository.Get(filter: s => s.COD_TAR_ID == Clientes.COD_TARIFA && s.SUC_ID == Clientes.CTE_SUC_ID && s.CARGO_PROD_ID == piCargoId)
                             orderby p.VAL_HASTA
                             select new { p.VAL_HASTA, p.VAL_PORCENTAJE, p.VAL_VALOR, p.VAL_ADICIONAL };


            foreach (var valor in cargosProd)
            {
                if(Monto <= valor.VAL_HASTA)
                {
                    dRetorno = valor.VAL_VALOR;
                    break;
                }
                   

            }



            return dRetorno;

        }

        private void txtPeso_TextChanged(object sender, EventArgs e)
        {
          
        }


        void CarcularUnidades()
        {
            int iProductoId = Convert.ToInt32(cmbProducto.SelectedValue);

            var cargosExits = unitOfWork.CargosProductoRepository.Get(filter: s => s.PROD_ID == iProductoId && s.Cargos.CAR_BASE_ID == 25 && s.Cargos.CAR_ESTADO == true); /*tipo cargos*/
                          
            // var cargosProd = unitOfWork.CargosProductoRepository.GetByID(iCargoProd);

            decimal dPeso = Convert.ToDecimal(txtPeso.Text);

            oUnidades.Rows.Clear();

            foreach(var cargo in cargosExits)
            {
                DataRow oRow = oUnidades.NewRow();

                oRow["ID"] = -1;
                oRow["CARGO_PROD_ID"] = cargo.CARGO_PROD_ID;
                oRow["Desc"] = cargo.Cargos.CAR_DESCRIPCION;
                oRow["Tasa"] = cargo.TasaCambio.FACTOR_CONV;
                oRow["Monto"] = dPeso.ToString();

                oRow["MontoAplicar"]  = BuscarMontoAplicar(cargo.CARGO_PROD_ID, dPeso);

                

                if (cargo.Cargos.CAR_FIJO_MULTIPLICAR == "F")
                {
                    if (Convert.ToDecimal(oRow["MontoAplicar"]) < Convert.ToDecimal(cargo.Cargos.CAR_MINIMO_FACTURAR))
                    {
                        Convert.ToDecimal(oRow["MontoAplicar"] = Convert.ToDecimal(cargo.Cargos.CAR_MINIMO_FACTURAR));
                    }

                    oRow["MontoLocal"] = Convert.ToDecimal(oRow["MontoAplicar"]) * cargo.TasaCambio.FACTOR_CONV;
                   
                }
                else
                {
                    if (Convert.ToDecimal(oRow["Monto"]) < Convert.ToDecimal(cargo.Cargos.CAR_MINIMO_FACTURAR))
                    {
                        oRow["Monto"] = Convert.ToDecimal(cargo.Cargos.CAR_MINIMO_FACTURAR);
                    }

                    oRow["MontoLocal"] = Convert.ToDecimal(oRow["Monto"]) * Convert.ToDecimal(oRow["MontoAplicar"]) * cargo.TasaCambio.FACTOR_CONV;
                }
                    


                oUnidades.Rows.Add(oRow);


            }



            //

        }

        private void txtPeso_Leave(object sender, EventArgs e)
        {
            //if (iNumeroEPS != -1)
               // CarcularUnidades();
        }



    }
}
