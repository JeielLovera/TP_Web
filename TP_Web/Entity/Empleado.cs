using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.ComponentModel;

namespace Entity
{
    public class Empleado
    {
        public int CEmpleado { get; set; }
        public String NEmpleado { get; set; }
        public int CDniEmpleado { get; set; }
        public String TDireccionEmpleado{ get; set; }
        public int NumTelefonoEmpleado { get; set; }        
        public bool FActivo { get; set; }
        public Rol CRol { get; set; } 
        public Empleado CJefe { get; set; }

    }
}
