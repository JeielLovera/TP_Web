using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Tipo_Direccion
    {
        [DisplayName("Código Tipo")]
        public int CTipo { get; set; }
        [DisplayName("Tipo")]
        public string NTipo { get; set; }
    }
}
