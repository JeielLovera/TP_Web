using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Orden_Producto
    {
        public int COrden_Producto { get; set; }
        public Orden COrden { get; set; }
        public Producto CProducto { get; set; }
        public Empleado CEmpleado { get; set; }
        public int QOrdenProducto { get; set; }
    }
}
