using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Venta_Producto
    {
        public Producto CProducto { get; set; }
        public Venta CVenta { get; set; }
        public int QCantidad { get; set; }

    }
}
