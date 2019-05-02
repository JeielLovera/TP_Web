using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entity
{
    public class TipoIngrediente
    {
        [DisplayName("Código Ingrediente")]
        public int CTipoIngrediente { get; set; }
        [DisplayName("Ingrediente")]
        public String NTipoIngrediente { get; set; }
    }
}
