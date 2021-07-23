using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapaPresentacion;
using CapaDatos;

namespace RegistroAlumno
{
    public partial class frmAlumno : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;
        public frmAlumno()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre del Alumno");
        }
        //Mostrar Mensaje de confirmacion

            private void MensajeOk(string Mensaje)
            {
            MessageBox.Show(Mensaje,"Registro de Alumnos",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }





        //Mostrar mensaje de error

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Registro de Alumnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Metodo para limpiar todos los controles del formulario

            private void Limpiar()
            {
            this.txtIDAlumno.Text = string.Empty;
            this.txtCodigo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            
            

            }

        //Metodo para habilitar los controles

            private void  Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtApellido.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtIDAlumno.ReadOnly = !valor;
            
        }

        //Habilitar botones

            private void Botones()
            {

                if(this.IsNuevo || this.IsEditar)
                {
                    this.Habilitar(true);
                    this.btnNuevo.Enabled  = false;
                    this.btnGuardar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnCancelar.Enabled  = true;

                }
                else
                {
                        this.Habilitar(false);
                        this.btnNuevo.Enabled = true;
                        this.btnGuardar.Enabled = false;
                        this.btnEditar.Enabled = true;
                        this.btnCancelar.Enabled = false;
                }

            }

        //Metodo para ocultar columnas

            private void OcultarColumnas()
            {
                this.dtgAlumnos.Columns[0].Visible = false;
                //this.dtgAlumnos.Columns[1].Visible = false;

            }

        //Metodo Mostrar Columnas

          

        //Metodo Mostrar

            private void Mostrar()
            {
                this.dtgAlumnos.DataSource = Nregistro.Mostrar();
                this.OcultarColumnas();
                lblTotal.Text = "Total de Registros: " + Convert.ToString(dtgAlumnos.Rows.Count);
            }

        // Metodo Buscar Por nombre

        private void BuscarPorNombre()
        {
            this.dtgAlumnos.DataSource = Nregistro.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dtgAlumnos.Rows.Count);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection SqlCon = new SqlConnection();
            SqlCon.ConnectionString = Conexion.Cn;
            SqlCon.Open();

            if(SqlCon.State ==ConnectionState.Open)
            {
                MessageBox.Show("Conexion realizada");
            }
            else
            {
                MessageBox.Show("No se pudo establecer la conexion con la base de datos");
            }

            
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();


            


        }

       

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarPorNombre();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarPorNombre();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if(this.txtNombre.Text==string.Empty)
                {
                    MensajeError("Faltan Ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Nombre");
                }
                else
                {
                    if(this.IsNuevo)
                    {
                        respuesta = Nregistro.Insertar(this.txtCodigo.Text.Trim().ToUpper(),this.txtNombre.Text.Trim().ToUpper(),this.txtApellido.Text.Trim().ToUpper(),this.txtDireccion.Text.Trim().ToUpper());
                    }
                    else
                    {
                        respuesta = Nregistro.Editar(Convert.ToInt32(this.txtIDAlumno.Text),this.txtCodigo.Text.Trim().ToUpper(), this.txtNombre.Text.Trim().ToUpper(), this.txtApellido.Text.Trim().ToUpper(), this.txtDireccion.Text.Trim().ToUpper());
                    }
                    if(respuesta.Equals("OK"))
                    {
                        if(this.IsNuevo)
                        {
                            this.MensajeOk("Se inserto de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizo de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(respuesta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                   
                    


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dtgAlumnos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.txtIDAlumno.Text = Convert.ToString(this.dtgAlumnos.CurrentRow.Cells["IdAlumno"].Value);
            this.txtCodigo.Text = Convert.ToString(this.dtgAlumnos.CurrentRow.Cells["CODIGO"].Value);
            this.txtNombre.Text = Convert.ToString(this.dtgAlumnos.CurrentRow.Cells["NOMBRE"].Value);
            this.txtApellido.Text = Convert.ToString(this.dtgAlumnos.CurrentRow.Cells["APELLIDO"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dtgAlumnos.CurrentRow.Cells["DIRECCION"].Value);
            


            this.tabControl1.SelectedIndex = 1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(!this.txtIDAlumno.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                MensajeError("Debe de seleccionar primero el registro a modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if(chkEliminar.Checked)
            {
                this.dtgAlumnos.Columns[0].Visible = true;
            }
            else
            {
                this.dtgAlumnos.Columns[0].Visible = false;
            }
        }

        private void dtgAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==dtgAlumnos.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dtgAlumnos.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Realmente desea eliminar los Registros", "Registro de Alumnos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {
                    string codigo;
                    string respuesta = "";

                    foreach (DataGridViewRow row in dtgAlumnos.Rows)
                    {
                        if(Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(row.Cells[1].Value);
                            respuesta = Nregistro.Eliminar(Convert.ToInt32(codigo));

                            if(respuesta.Equals("OK"))
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMantenimiento abrirform = new frmMantenimiento();
            abrirform.Show();
            this.Hide();
        }

        private void dtgAlumnos_DoubleClick(object sender, EventArgs e)
        {
            this.txtIDAlumno.Text = Convert.ToString(this.dtgAlumnos.CurrentRow.Cells["IdAlumno"].Value);
            this.txtCodigo.Text = Convert.ToString(this.dtgAlumnos.CurrentRow.Cells["CODIGO"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dtgAlumnos.CurrentRow.Cells["DIRECCION"].Value);
            this.txtNombre.Text = Convert.ToString(this.dtgAlumnos.CurrentRow.Cells["NOMBRE"].Value);

            tabControl1.SelectedIndex = 1;
        }
    }
}
