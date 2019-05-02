using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Rol
    {
        [DisplayName("Código Rol")]
        public int CRol { get; set; }
        [DisplayName("Rol")]
        public String NRol { get; set; }
        [DisplayName("Sueldo")]
        public double MSueldo { get; set; }
    }
}
