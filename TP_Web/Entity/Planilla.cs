using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace Entity
{
    public class Planilla
    {
        public Empleado CEmpleado { get; set; }
        public DateTime DFechaHRol { get; set; }
        public Rol CRol { get; set; }
        public float MSueldo { get; set; }
    }
}
