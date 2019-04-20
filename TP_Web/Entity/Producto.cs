using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace Entity
{
    public class Producto
    {
        public int CProducto { get; set; }
        public String NProducto { get; set; }
        public float MPrecio { get; set; }
        public TipoProducto CTipoProducto { get; set; }
    }
}
