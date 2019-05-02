using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Venta_Producto
    {
        [DisplayName("Código")]
        public int CVenta_Producto { get; set; }
        [DisplayName("Código Producto")]
        public Producto CProducto { get; set; }
        [DisplayName("Código Venta")]
        public Venta CVenta { get; set; }
        [DisplayName("Cantidad")]
        public int QCantidad { get; set; }

    }
}
