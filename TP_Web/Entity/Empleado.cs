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
        [DisplayName("Código Empleado")]
        public int CEmpleado { get; set; }
        [DisplayName("Nombre Empleado")]
        public String NEmpleado { get; set; }
        [DisplayName("DNI")]
        public int CDniEmpleado { get; set; }
        [DisplayName("Dirección")]
        public String TDireccionEmpleado{ get; set; }
        [DisplayName("Telefono")]
        public int NumTelefonoEmpleado { get; set; }
        [DisplayName("Activo")]
        public bool FActivo { get; set; }
        [DisplayName("Rol")]
        public Rol CRol { get; set; }
        [DisplayName("Jefe")]
        public Empleado CJefe { get; set; }

    }
}
