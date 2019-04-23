using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;
using Data.Implementation;

namespace Business.Implementation
{
    public class DeliveryService : IDeliveryService
    {
        private IDeliveryRepository deliveryRepository = new DeliveryRepository();
        private IVentaRepository ventaRepository = new VentaRepository();
        private IEmpleadoRepository empleadoRepository = new EmpleadoRepository();
        private ICalle_Avenida_JironRepository calle_Avenida_JironRepository = new Calle_Avenida_JironcsRepository();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Delivery> FindAll()
        {
            return deliveryRepository.FindAll();
        }

        public Delivery FindById(int? id)
        {
            return deliveryRepository.FindById(id);
        }

        public Delivery FindById(int? id, int? id2)
        {
            throw new NotImplementedException();
        }

        public Delivery FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Delivery t)
        {
            Venta venta = ventaRepository.FindById(t.CDelivery.CVenta);
            Empleado empleado = empleadoRepository.FindById(t.CEmpleadoMotorizado.CEmpleado);
            Calle_Avenida_Jiron calle = calle_Avenida_JironRepository.FindById(t.CCalle_Av_Jiron.CCalle_Av_Jiron);

            t.CDelivery = venta;
            t.CEmpleadoMotorizado = empleado;
            t.CCalle_Av_Jiron = calle;

            return deliveryRepository.Insert(t);
        }

        public bool Update(Delivery t)
        {
            throw new NotImplementedException();
        }
    }
}
