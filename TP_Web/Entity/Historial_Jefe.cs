using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Historial_Jefe
    {
        public Empleado CEmpleado { get; set; }
        public DateTime DFechaHJefe { get; set; }
        public Empleado CJefe { get; set; }
    }
}
