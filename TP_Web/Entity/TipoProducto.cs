using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class TipoProducto
    {
        [DisplayName("Código Tipo")]
        public int CTipoProducto { get; set; }
        [DisplayName("Tipo")]
        public String NTipoProducto { get; set; }

    }
}
