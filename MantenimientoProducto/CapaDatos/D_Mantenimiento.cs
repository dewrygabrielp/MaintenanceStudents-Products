using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaComun;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;

namespace CapaDatos
{
    public class D_Mantenimiento
    {
        //Instancio la clase E_Mantenimiento para utilizar sus metodos o atributos
        E_Mantenimiento ObjE = new E_Mantenimiento();
        //Declaracion de parametros y metodos que haran puente con la base de datos

        public DataTable Mostrar()
        {
            DataTable dt = new DataTable("CATEGORIA");
            SqlConnection SqlCon = new SqlConnection();

            //Codigo
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlCmd);
                SqlData.Fill(dt);

            }
            catch(Exception ex)
            {
                dt = null;
                
            }
            return dt;
        }

        //Metodo buscar por categorias

        public DataTable Buscar(E_Mantenimiento Categoria)
        {
            DataTable dt = new DataTable("CATEGORIA");
            SqlConnection SqlCon = new SqlConnection();

            //Codigo

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParBuscar = new SqlParameter();
                ParBuscar.ParameterName = "@textobuscar";
                ParBuscar.SqlDbType = SqlDbType.VarChar;
                ParBuscar.Size = 50;
                ParBuscar.Value = Categoria.Textobuscar;
                SqlCmd.Parameters.Add(ParBuscar);

                SqlCmd.ExecuteNonQuery();

                SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
                SqlDa.Fill(dt);

            }
            catch(Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        public string Insertar(E_Mantenimiento Categoria)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            
            //Codigo
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdproducto = new SqlParameter();
                ParIdproducto.ParameterName = "@idproducto";
                ParIdproducto.DbType = DbType.Int32;
                ParIdproducto.Direction = ParameterDirection.Output;
                ParIdproducto.Value = Categoria.IDproducto;
                SqlCmd.Parameters.Add(ParIdproducto);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigoproducto";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 6;
                ParCodigo.Direction = ParameterDirection.Output;
                ParCodigo.Value = Categoria.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Categoria.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Value = Categoria.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);


                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE INSERTO EL REGISTRO";
            }
            catch(Exception ex)
            {
                respuesta = (ex.Message + ex.StackTrace);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return respuesta;
        }
        public string Editar(E_Mantenimiento Categoria)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            //Codigo
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdproducto = new SqlParameter();
                ParIdproducto.ParameterName = "@idproducto";
                ParIdproducto.DbType = DbType.Int32;
                ParIdproducto.Value = Categoria.IDproducto;
                SqlCmd.Parameters.Add(ParIdproducto);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigoproducto";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 6;
                ParCodigo.Value = Categoria.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Categoria.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Value = Categoria.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);


                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE ACTUALIZO EL REGISTRO";
            }
            catch (Exception ex)
            {
                respuesta = (ex.Message + ex.StackTrace);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return respuesta;
        }

        public string Eliminar(E_Mantenimiento Categoria)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            //Codigo
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdproducto = new SqlParameter();
                ParIdproducto.ParameterName = "@idproducto";
                ParIdproducto.DbType = DbType.Int32;
                ParIdproducto.Value = Categoria.IDproducto;
                SqlCmd.Parameters.Add(ParIdproducto);

                


                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE ELIMINO EL REGISTRO";
            }
            catch (Exception ex)
            {
                respuesta = (ex.Message + ex.StackTrace);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return respuesta;
        }
    }
}
