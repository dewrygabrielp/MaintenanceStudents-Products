using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace RegistroAlumno
{
    public class Nregistro
    {
        //Metodo para insertar desde la clase Dregistro

        public static string Insertar(string codigo, string nombre, string apellido, string direccion)
        {
            Dregistro Obj = new Dregistro();
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Direccion = direccion;

            return Obj.Insertar(Obj);
        }

        //Metodo para Editar que llama al metodo Editar de la clase Dregistro

        public static string Editar(int idalumno, string codigo, string nombre, string apellido, string direccion)
        {
            Dregistro Obj = new Dregistro();
            Obj.IdAlumnos = idalumno;
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Direccion = direccion;

            return Obj.Editar(Obj);
        }

        //Metodo Eliminar que llama al metodo Eliminar de la clase Dregistro

        public static string Eliminar(int idalumno)
        {
            Dregistro Obj = new Dregistro();
            Obj.IdAlumnos = idalumno;
            
            return Obj.Eliminar(Obj);
        }

        //Metodo Buscar por nombre que llama al metodo BuscarNombre de la clase Dregistro

        public static DataTable BuscarNombre(string textobuscar)
        {
            Dregistro Obj = new Dregistro();
            Obj.Textobuscar = textobuscar;


            return Obj.BuscarNombre(Obj);
        }

        //Metodo Mostrar que llama al metodo Mostrar de la clase Dregistro

        public static DataTable Mostrar()
        {
            return new Dregistro().Mostrar();

        }
    }
}
