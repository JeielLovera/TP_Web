using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Order_Producto
    {
        public Producto CProducto { get; set; }
        public Venta CVenta { get; set; }
        public Orden COrden { get; set; }
        public Empleado CEmpleado { get; set; }
        public int QOrdenProducto { get; set; }
    }
}
