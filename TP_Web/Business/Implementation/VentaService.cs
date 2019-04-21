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
        private IMesaRepository mesaRepository = new MesaRepository();
        private ILocalRepository localRepository = new LocalRepository();
        private IEmpleadoRepository empleadoRepository = new EmpleadoRepository();

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
            Local local = localRepository.FindById(t.CMesa.CLocal.CLocal);
            Mesa mesa = mesaRepository.FindById(t.CMesa.CMesa);
            Empleado mozo = empleadoRepository.FindById(t.CMozo.CEmpleado);
            t.CLocal = local;
            t.CMesa = mesa;
            t.CMozo = mozo;
            return ventaRepository.Insert(t);
        }

        public bool Update(Venta t)
        {
            Local local = localRepository.FindById(t.CMesa.CLocal.CLocal);
            Mesa mesa = mesaRepository.FindById(t.CMesa.CMesa);
            Empleado mozo = empleadoRepository.FindById(t.CMozo.CEmpleado);
            t.CLocal = local;
            t.CMesa = mesa;
            t.CMozo = mozo;
            return ventaRepository.Update(t);
        }

        public Venta FindById(int? id, int? id2)
        {
            throw new NotImplementedException();
        }

        public Venta FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }
    }
}
