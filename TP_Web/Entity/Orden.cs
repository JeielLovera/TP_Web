using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.ComponentModel;

namespace Entity
{
    public class Orden
    {
        [DisplayName("Código Orden")]
        public int COrden { get; set; }
        [DisplayName("Cóidgo Venta")]
        public Venta CVenta { get; set; }
        [DisplayName("Atendida")]
        public bool FOrdenAtendida { get; set; }
        [DisplayName("Hora")]
        public DateTime DHoraEntrega { get; set; }
    }
}
