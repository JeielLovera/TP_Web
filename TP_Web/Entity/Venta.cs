using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Venta
    {
        public int CVenta { get; set; }
        public Local CLocal { get; set; }
        public double MCostoVenta { get; set; }
        public DateTime DFechaVenta { get; set; }
        public double QDescuento { get; set; }
        public double IGV { get; set; }
        public Empleado CMotorizado { get; set; }
        public Cliente CCliente { get; set; }
        public DateTime DHoraEntrega { get; set; }
        public String TReferencia { get; set; }

    }
}
