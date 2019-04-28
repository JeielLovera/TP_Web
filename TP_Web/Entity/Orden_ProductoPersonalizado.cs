using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Orden_ProductoPersonalizado
    {
        public int COrden_Pro_Per { get; set; }
        public Orden COrden { get; set; }
        public Ingrediente CIngrediente { get; set; }
        public Empleado CEmpleado { get; set; }
        public int QOrdenProductoPersonalizado { get; set; }
    }
}
