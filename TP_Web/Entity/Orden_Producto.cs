using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Orden_Producto
    {
        [DisplayName("Código")]
        public int COrden_Producto { get; set; }
        [DisplayName("Código Orden")]
        public Orden COrden { get; set; }
        [DisplayName("Código Producto")]
        public Producto CProducto { get; set; }
        [DisplayName("Código Empleado")]
        public Empleado CEmpleado { get; set; }
        [DisplayName("Cantidad")]
        public int QOrdenProducto { get; set; }
    }
}
