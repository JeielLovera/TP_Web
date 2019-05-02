using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
     public class Distrito
    {

        [DisplayName("Código Distrito")]
        public int CDistrito { get; set; }
        [DisplayName("Distrito")]
        public string NDistrito { get; set; }
    }
}
