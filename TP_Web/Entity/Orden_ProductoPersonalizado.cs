using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Orden_ProductoPersonalizado
    {
        [DisplayName("Código")]
        public int COrden_Pro_Per { get; set; }
        [DisplayName("Código Orden")]
        public Orden COrden { get; set; }
        [DisplayName("Código Ingrediente")]
        public Ingrediente CIngrediente { get; set; }
        [DisplayName("Código Empleado")]
        public Empleado CEmpleado { get; set; }
        [DisplayName("Cantidad")]
        public int QOrdenProductoPersonalizado { get; set; }
    }
}
