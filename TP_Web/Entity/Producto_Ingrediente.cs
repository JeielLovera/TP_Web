using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Producto_Ingrediente
    {
        public int CProducto_Ingrediente { get; set; }
        public Producto CProducto { get; set; }
        public Ingrediente CIngrediente { get; set; }
        public int QUsadaIngrediente { get; set; }
        public String NUnidadMedidaUsada { get; set; }
    }
}
