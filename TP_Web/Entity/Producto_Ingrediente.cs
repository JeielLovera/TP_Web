using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Producto_Ingrediente
    {
        [DisplayName("Código")]
        public int CProducto_Ingrediente { get; set; }
        [DisplayName("Código Producto")]
        public Producto CProducto { get; set; }
        [DisplayName("Código Ingrediente")]
        public Ingrediente CIngrediente { get; set; }
        [DisplayName("Cantidad")]
        public int QUsadaIngrediente { get; set; }
        [DisplayName("Medida")]
        public String NUnidadMedidaUsada { get; set; }
    }
}
