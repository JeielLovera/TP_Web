using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Venta_ProductoPersonalizado
    {
        [DisplayName("Código")]
        public int CVenta_Pro_Per { get; set; }
        [DisplayName("Código Venta")]
        public Venta CVenta { get; set; }
        [DisplayName("Código Ingrediente")]
        public Ingrediente CIngrediente { get; set; }
        [DisplayName("Cantidad")]
        public int QUsadaIngrediente { get; set; }
        [DisplayName("Precio por gramo")]
        public double PrecioXGramo { get; set; }
    }
}
