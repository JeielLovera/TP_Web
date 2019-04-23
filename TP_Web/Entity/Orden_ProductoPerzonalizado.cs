using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Orden_ProductoPerzonalizado
    {
        public Venta CVenta { get; set; }
        public Orden COrden { get; set; }
        public Ingrediente CIngrediente { get; set; }
        public Empleado CEmpleado { get; set; }
        public int QOrdenProductoPerzonalizado { get; set; }
        public string NUnidadMedidaUsada { get; set; }
    }
}
