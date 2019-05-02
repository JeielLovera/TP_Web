using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Ingrediente
    {
        [DisplayName("Código Ingrediente")]
        public int CIngrediente { get; set; }
        [DisplayName("Ingrediente")]
        public String NIngrediente { get; set; }
        [DisplayName("Cantidad")]
        public float QUnidadMedidaIngrediente { get; set; }
        [DisplayName("Medida")]
        public String NUnidadMedidaIngrediente { get; set; }
        [DisplayName("Tipo Ingrediente")]
        public TipoIngrediente CTipoIngrediente { get; set; }


    }
}
