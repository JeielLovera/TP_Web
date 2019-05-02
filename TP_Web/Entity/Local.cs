using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Local
    {
        [DisplayName("Código Local")]
        public int CLocal{ get; set; }
        [DisplayName("Dirección")]
        public String TDireccionLocal { get; set; }
        [DisplayName("Teléfono")]
        public int NumTelefono { get; set; }
    }
}
