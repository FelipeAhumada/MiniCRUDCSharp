using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjCrudSqlServer
{
    class ClsProducto
    {
        private string _strNombre;
        public string strNombre{
            get{
                return this.strNombre;
            }
        set{
            this.strNombre = value;
            }
        }

        private string _strDescripcion;
        public string strDescripcion
        {
         get{
                return this.strDescripcion;
            }
        set{
                this.strDescripcion = value;
            }
        }
        private string _strMarca;
        public string strMarca
        {
            get
            {
                return this.strMarca;
            }
            set
            {
                this.strMarca = value;
            }
        }
        private int _intPrecio;
        public int intPrecio
         {
            get
            {
                return this.intPrecio;
            }
            set
            {
                this.intPrecio = value;
            }
        }
        private int _intStock;
        public int intStock
        {
            get
            {
                return this.intStock;
            }
            set
            {
                this.intStock = value;
            }
        }
        private int _intIdTipoProducto;
        public int intIdTipoProducto
        {
            get
            {
                return this.intIdTipoProducto;
            }
            set
            {
                this.intIdTipoProducto = value;
            }
        }
 
    }
}
