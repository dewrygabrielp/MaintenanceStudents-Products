using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaComun;
using CapaDatos;



namespace CapaNegocios
{
    public class N_Mantenimiento
    {
        //Los procedimientos en esta capa estaran relacionados con los procedimientos de la D_Mantenimientos para servir como puente con la capa presentacion

        public static DataTable Mostrar()
        {
            
            return new D_Mantenimiento().Mostrar();
        }
        public DataTable Buscar(E_Mantenimiento Categoria)
        {
            D_Mantenimiento ObjD = new D_Mantenimiento();
            return ObjD.Buscar(Categoria);
            
        }
        public string Insertar(E_Mantenimiento Categoria)
        {
            D_Mantenimiento ObjD = new D_Mantenimiento();
            return ObjD.Insertar(Categoria);
        }
         public static string Editar(int idproducto, string codigo, string nombre, string descripcion)
        {
             D_Mantenimiento ObjD = new D_Mantenimiento();
             E_Mantenimiento ObjE = new E_Mantenimiento();
             ObjE.IDproducto = idproducto;
             ObjE.Codigo = codigo;
             ObjE.Nombre = nombre;
             ObjE.Descripcion = descripcion;
             return ObjD.Editar(ObjE);
        }
        public static string Eliminar(int idproducto)
        {
            D_Mantenimiento ObjD = new D_Mantenimiento();
            E_Mantenimiento ObjE = new E_Mantenimiento();
            ObjE.IDproducto = idproducto;

            return ObjD.Eliminar(ObjE);
        }
    }
}
