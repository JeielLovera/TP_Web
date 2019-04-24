using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Direccion
    {
        public int CDireccion { get; set; }
        public Distrito CDistrito { get; set; }
        public Tipo_Direccion CTipoDireccion { get; set; }
        public string NDireccion { get; set; }

    }
}
