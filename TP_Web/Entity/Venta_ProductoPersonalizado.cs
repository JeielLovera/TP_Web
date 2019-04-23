using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Venta_ProductoPersonalizado
    {
        public Venta CVenta { get; set; }
        public Ingrediente CIngrediente { get; set; }
        public int QUsadaIngrediente { get; set; }
        public int PrecioXGramo { get; set; }
    }
}
