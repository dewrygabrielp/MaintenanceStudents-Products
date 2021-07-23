using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaComun
{
    public class E_Mantenimiento
    {
        private int _IDproducto;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private string _Textobuscar;

        public int IDproducto { get => _IDproducto; set => _IDproducto = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Textobuscar { get => _Textobuscar; set => _Textobuscar = value; }
        


        //Constructor vacio
        public E_Mantenimiento()
        {

        }

        //Constructor con parametros

        public E_Mantenimiento(int idproducto, string nombre, string descripcion, string codigo, string textobuscar)
        {
            this.IDproducto = idproducto;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Textobuscar = textobuscar;
        }
    }
}
