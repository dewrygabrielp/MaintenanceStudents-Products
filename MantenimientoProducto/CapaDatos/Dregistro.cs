using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.CodeDom;
using CapaDatos;

namespace RegistroAlumno
{
   public class Dregistro
    {
        private int _IdAlumnos;
        private string _Codigo;
        private string _Nombre;
        private string _Apellido;
        private string _Direccion;
        private string _Textobuscar;

        public int IdAlumnos { get => _IdAlumnos; set => _IdAlumnos = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Textobuscar { get => _Textobuscar; set => _Textobuscar = value; }

        //Constructor vacio

        public Dregistro()
        {

        }

        //Constructor con parametros

        public Dregistro(int idalumnos, string codigo, string nombre, string apellido, string direccion, string textobuscar)
        {
            this.IdAlumnos = idalumnos;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Direccion = direccion;
            this.Textobuscar = textobuscar;
        }

        // Metodo Insertar

        public string Insertar(Dregistro registro)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            
            try
            {
                //Codigo

                SqlCon.ConnectionString = Conexion.Cn1;
                SqlCon.Open();

                //Establecer comando

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_alumno";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdAlumno = new SqlParameter();
                ParIdAlumno.ParameterName = "@idalumno";
                ParIdAlumno.DbType = DbType.Int32;
                ParIdAlumno.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdAlumno);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName="@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 6;
                ParCodigo.Value = registro.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 25;
                ParNombre.Value = registro.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido"; 
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 25;
                ParApellido.Value = registro.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 200;
                ParDireccion.Value = registro.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                //Ejecutamos el comando

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Ingreso El Registro";

            }
            catch(Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return respuesta;
            
        }

        // Metodo Editar

        public string Editar(Dregistro registro)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
          
            try
            {
                //Codigo

                SqlCon.ConnectionString = Conexion.Cn1;
                SqlCon.Open();

                //Establecer comando

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditare_alumno";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdAlumno = new SqlParameter();
                ParIdAlumno.ParameterName = "@idalumno";
                ParIdAlumno.DbType = DbType.Int32;
                ParIdAlumno.Value = registro.IdAlumnos;
                SqlCmd.Parameters.Add(ParIdAlumno);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 6;
                ParCodigo.Value = registro.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 25;
                ParNombre.Value = registro.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 25;
                ParApellido.Value = registro.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 200;
                ParDireccion.Value = registro.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                //Ejecutamos el comando

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo El Registro";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return respuesta;
        }

        // Metodo Eliminar

        public string Eliminar(Dregistro registro)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
          

            try
            {
                //Codigo

                SqlCon.ConnectionString = Conexion.Cn1;
                SqlCon.Open();

                //Establecer comando

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_alumnos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdAlumno = new SqlParameter();
                ParIdAlumno.ParameterName = "@idalumno";
                ParIdAlumno.DbType = DbType.Int32;
                ParIdAlumno.Value = registro.IdAlumnos;
                SqlCmd.Parameters.Add(ParIdAlumno);

               

                //Ejecutamos el comando

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ELIMINO El Registro";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return respuesta;
        }


        // Metodo Mostrar
        public DataTable Mostrar()
        {
            DataTable dt = new DataTable("ALUMNO");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn1;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostar_alumnos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
                SqlDa.Fill(dt);

               
            }
            catch(Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        // Metodo Buscar
        public DataTable BuscarNombre(Dregistro registro)
        {
            DataTable dt = new DataTable("ALUMNO");
            SqlConnection SqlCon = new SqlConnection();
          

            try
            {


                SqlCon.ConnectionString = Conexion.Cn1;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;

                SqlCmd.CommandText = "spbuscar_alumnos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = registro.Textobuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
                SqlDa.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }        

    }

   
    

      

         
    

    
    
    
  
   
    
}
