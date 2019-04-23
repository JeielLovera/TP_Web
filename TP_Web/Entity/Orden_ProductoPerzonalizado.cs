using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Orden_ProductoPerzonalizado
    {
        public int CVenta { get; set; }
        public int COrden { get; set; }
        public int CIngrediente { get; set; }
        public int CEmpleado { get; set; }
        public int QOrdenProductoPerzonalizado { get; set; }
        public string NUnidadMedidaUsada { get; set; }
    }
}
