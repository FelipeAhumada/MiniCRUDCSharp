using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjCrudSqlServer
{
    class ClsTipoProducto
    {
        private int _intIdTipoProducto;
        public int intIdTipoProducto{
            get {
                return this.intIdTipoProducto;
            }set{
                this.intIdTipoProducto = value;
            }
        }
        private string _strIdTipo;
        public string strTipo
        {
            get
            {
                return this.strTipo;
            }
            set
            {
                this.strTipo = value;
            }
        }
        //Otra Opcion mas corta
        //public string amePerson { get; set; }

        //Otra opcion 
        //private string _name;
        //public string Name
        //{
        //    get { return _name; }
         //   set { _name = value; } // value is a special keyword here
       // }


    }
}
