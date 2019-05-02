using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Venta
    {
        [DisplayName ("Código de Venta")]
        public int CVenta { get; set; }
        [DisplayName("Código del Local")]
        public Local CLocal { get; set; }
        [DisplayName("Monto")]
        public double MCostoVenta { get; set; }
        [DisplayName("Fecha")]
        public DateTime DFechaVenta { get; set; }
        [DisplayName("Descuento")]
        public double QDescuento { get; set; }
        [DisplayName("IGV")]
        public double IGV { get; set; }
        [DisplayName("Código del Motorizado")]
        public Empleado CMotorizado { get; set; }
        [DisplayName("Código del Cliente")]
        public Cliente CCliente { get; set; }
        [DisplayName("Hora de entrega")]
        public DateTime DHoraEntrega { get; set; }
        [DisplayName("Referencia")]
        public String TReferencia { get; set; }

    }
}
