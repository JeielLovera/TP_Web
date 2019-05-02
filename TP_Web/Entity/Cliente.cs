using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.ComponentModel;

namespace Entity
{
    public class Cliente
    {
        [DisplayName("Código del Cliente")]
        public int CCliente { get; set; }
        [DisplayName("Nombre del Cliente")]
        public string NCliente { get; set; }
        [DisplayName("Telefono")]
        public int NumTelefonoCliente { get; set; }
        [DisplayName("Dirección")]
        public Direccion CDireccion { get; set; }
    }
}
