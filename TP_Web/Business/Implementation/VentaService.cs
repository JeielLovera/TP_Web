using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Implementation;
using Entity;

namespace Business.Implementation
{
    public class VentaService : IVentaService
    {
        private IVentaRepository ventaRepository = new VentaRepository();
        private ILocalRepository localRepository = new LocalRepository();
        private IEmpleadoRepository empleadoRepository = new EmpleadoRepository();
        private IClienteRepository clienteRepository = new ClienteRepository();
        private IDireccionRepository direccionRepository = new DireccionRepository();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Venta> FindAll()
        {
            return ventaRepository.FindAll();
        }

        public Venta FindById(int? id)
        {
            return ventaRepository.FindById(id);
        }

        public bool Insert(Venta t)
        {
            Local local = localRepository.FindById(t.CLocal.CLocal);            
            Empleado motorizado = empleadoRepository.FindById(t.CMotorizado.CEmpleado);
            Cliente cliente = clienteRepository.FindById(t.CCliente.CCliente);
            Direccion direccion = direccionRepository.FindById(t.CCliente.CDireccion.CDireccion);
            t.CLocal = local;
            t.CMotorizado = motorizado;
            t.CCliente = cliente;
            t.CCliente.CDireccion = direccion;
            return ventaRepository.Insert(t);
        }

        public bool Update(Venta t)
        {
            Local local = localRepository.FindById(t.CLocal.CLocal);
            Empleado motorizado = empleadoRepository.FindById(t.CMotorizado.CEmpleado);
            Cliente cliente = clienteRepository.FindById(t.CCliente.CCliente);
            Direccion direccion = direccionRepository.FindById(t.CCliente.CDireccion.CDireccion);
            t.CLocal = local;
            t.CMotorizado = motorizado;
            t.CCliente = cliente;
            t.CCliente.CDireccion = direccion;
            return ventaRepository.Update(t);
        }
        
    }
}
