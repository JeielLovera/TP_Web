using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Direccion
    {
        [DisplayName("Código Dirección")]
        public int CDireccion { get; set; }
        [DisplayName("Distrito")]
        public Distrito CDistrito { get; set; }
        [DisplayName("Tipo Direccion")]
        public Tipo_Direccion CTipoDireccion { get; set; }
        [DisplayName("Direccion")]
        public string NDireccion { get; set; }

    }
}
