using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Entity
{
    public class Cliente
    {
        public int CCliente { get; set; }
        public string NCliente { get; set; }
        public int NumTelefonoCliente { get; set; }
        public Direccion CDireccion { get; set; }
    }
}
