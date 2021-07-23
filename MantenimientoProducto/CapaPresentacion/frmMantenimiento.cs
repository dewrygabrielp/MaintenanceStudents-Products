using CapaComun;
using CapaDatos;
using CapaNegocios;
using RegistroAlumno;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class frmMantenimiento : Form
    {
        private bool IsNuevo=false;
        private bool IsEditar=false;
        E_Mantenimiento ObjEntidad = new E_Mantenimiento();
        N_Mantenimiento ObjNegocio = new N_Mantenimiento();
        public frmMantenimiento()
        {
            InitializeComponent();

            this.ttMensaje.SetToolTip(txtNombre, "Ingrese el nombre");
            this.ttMensaje.SetToolTip(txtDescripcion, "Ingrese Descripcion");
            
        }
        private void botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.chkEliminar.Checked = false;



            }
            else
            {
                this.habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
                this.chkEliminar.Checked = false;
            }
        }
        private void Mostrar()
        {

            this.dgvMantenimiento.DataSource = N_Mantenimiento.Mostrar();
            this.ocultarColumns();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dgvMantenimiento.Rows.Count);
        }
        private void ocultarColumns()
        {
            this.dgvMantenimiento.Columns[1].Visible = false;
        }
        private void limpiar()
        {
            txtID.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            this.chkEliminar.Checked = false;
        }   
        private void habilitar(bool valor)
        {
            this.txtID.ReadOnly = !valor;
            this.txtCodigo.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.chkEliminar.Checked = !valor;

        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de MANTENIMIENTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de MANTENIMIENTO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 203)
            {
                MenuVertical.Width = 57;
            }
            else
            {
                MenuVertical.Width = 203;
            }
        }

        private void frmMantenimiento_Load(object sender, EventArgs e)
        {
            SqlConnection SqlCon = new SqlConnection();
            SqlCon.ConnectionString = Conexion.Cn;
            SqlCon.Open();

            if (SqlCon.State == ConnectionState.Open)
            {
                MessageBox.Show("CONEXION ESTABLECIDA CORRECTAMENTE","MANTENIMIENTO PRODUCTO",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("FALLO AL INTENTAR CREAR LA CONEXION");
            }
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.habilitar(false);
            this.botones();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.botones();
            this.limpiar();
            this.habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(!this.txtID.Equals(""))
            {
                this.IsEditar = true;
                this.botones();
                this.habilitar(true);

            }
            else
            {
                MensajeError("Debe seleccionar primero el registro a modificar");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           string  respuesta = "";
            if(txtNombre.Text==string.Empty)
            {
                MensajeError("Falta ingresar el campo");
                ErrorIcono.SetError(txtNombre, "Ingrese un nombre");
            }
            else
            {
                if(this.IsNuevo)
                {
                    
                        ObjEntidad.Nombre = txtNombre.Text.Trim().ToUpper();
                        ObjEntidad.Descripcion = txtDescripcion.Text.Trim().ToUpper();

                        ObjNegocio.Insertar(ObjEntidad);
                    
                 

                }
                else
                {
                    respuesta = N_Mantenimiento.Editar(Convert.ToInt32(this.txtID.Text), this.txtCodigo.Text.Trim().ToUpper(),
                    this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.ToUpper());
                   



                }
                if(this.IsNuevo)
                {
                    if (respuesta.Equals("OK"))
                    {
                        //
                    }
                    else
                    {
                       this.MensajeOk("Se inserto Correctamente");
                    }
                }
                else
                {
                    this.MensajeOk("Se Actualizo el registro correctamente");
                }
                this.IsNuevo = false;
                this.IsEditar = false;
                this.botones();
                this.limpiar();
                this.Mostrar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.botones();
            this.limpiar();
            this.habilitar(false);
        }

        private void chkEliminar_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dgvMantenimiento.Columns[0].Visible = true;
            }
            else
            {
                this.dgvMantenimiento.Columns[0].Visible = false;
            }
        }

        private void dgvMantenimiento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvMantenimiento.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dgvMantenimiento.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Realmente desea eliminar los Registros", "MANTENIMIENTO DE EMPLEADOS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {
                    string codigo;
                    string respuesta = "";

                    foreach (DataGridViewRow row in dgvMantenimiento.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(row.Cells[1].Value);
                            respuesta = N_Mantenimiento.Eliminar(Convert.ToInt32(codigo));

                            if (respuesta.Equals("OK"))
                            {
                                MensajeOk("Se elimino correctamente el registro");
                            }
                            else
                            {
                                MensajeError(respuesta);
                            }
                        }
                    }
                    this.Mostrar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);

            }
        }

        private void dgvMantenimiento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMantenimiento_DoubleClick(object sender, EventArgs e)
        {
            this.txtID.Text = Convert.ToString(this.dgvMantenimiento.CurrentRow.Cells["IDPRODUCTO"].Value);
            this.txtCodigo.Text = Convert.ToString(this.dgvMantenimiento.CurrentRow.Cells["CODIGO"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dgvMantenimiento.CurrentRow.Cells["DESCRIPCION"].Value);
            this.txtNombre.Text = Convert.ToString(this.dgvMantenimiento.CurrentRow.Cells["NOMBRE"].Value);

            tabControl1.SelectedIndex = 1;
        }

        private void btnfromAlumnos_Click(object sender, EventArgs e)
        {
            frmAlumno abrirForm = new frmAlumno();
            abrirForm.Show();
            this.Hide();
        }

        private void pnlUp_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }
    }
}
