using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace Entity
{
    public class Orden
    {
        public int COrden { get; set; }
        public Venta CVenta { get; set; }        
        public bool FOrdenAtendida { get; set; }
        public DateTime DHoraEntrega { get; set; }
    }
}
