using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Delivery
    {
        public Venta CDelivery { get; set; }
        public Empleado CEmpleadoMotorizado { get; set; }
        public DateTime DHoraEntrega { get; set; }
        public Calle_Avenida_Jiron CCalle_Av_Jiron { get; set; }
        public int NumDireccionDelivery { get; set; }
        public string TReferencia { get; set; }

    }
}
