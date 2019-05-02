using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.ComponentModel;

namespace Entity
{
    public class Producto
    {
        [DisplayName("Código Producto")]
        public int CProducto { get; set; }
        [DisplayName("Producto")]
        public String NProducto { get; set; }
        [DisplayName("Precio")]
        public double MPrecio { get; set; }
        [DisplayName("Tipo Producto")]
        public TipoProducto CTipoProducto { get; set; }
    }
}
