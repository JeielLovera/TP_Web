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
    public class Orden_ProductoPerzonalizadoService : IOrden_ProductoPerzonalizadoService
    {
        private IOrden_ProductoPerzonalizadoRepository orden_per = new Orden_ProductoPerzonalizadoRepository();
        private IVentaRepository ventaRepository = new VentaRepository();
        private IOrdenRepository ordenRepository = new OrdenRepository();
        private IEmpleadoRepository empleadoRepository = new EmpleadoRepository();
        private IIngredienteRepository ingredienteRepository = new IngredienteRepository();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Orden_ProductoPerzonalizado> FindAll()
        {
           return orden_per.FindAll();
        }

        public Orden_ProductoPerzonalizado FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public Orden_ProductoPerzonalizado FindById(int? id, int? id2)
        {
            throw new NotImplementedException();
        }

        public Orden_ProductoPerzonalizado FindById(int? id, int? id2, int? id3)
        {
            return orden_per.FindById(id, id2, id3);
        }

        public bool Insert(Orden_ProductoPerzonalizado t)
        {
            Venta venta = ventaRepository.FindById(t.CVenta.CVenta);
            Orden orden = ordenRepository.FindById(t.COrden.COrden);
            Empleado empleado = empleadoRepository.FindById(t.CEmpleado.CEmpleado);
            Ingrediente ingrediente = ingredienteRepository.FindById(t.CIngrediente.CIngrediente);

            t.CVenta = venta;
            t.COrden = orden;
            t.CEmpleado = empleado;
            t.CIngrediente = ingrediente;


           return  orden_per.Insert(t);
        }

        public bool Update(Orden_ProductoPerzonalizado t)
        {
            Venta venta = ventaRepository.FindById(t.CVenta.CVenta);
            Orden orden = ordenRepository.FindById(t.COrden.COrden);
            Empleado empleado = empleadoRepository.FindById(t.CEmpleado.CEmpleado);
            Ingrediente ingrediente = ingredienteRepository.FindById(t.CIngrediente.CIngrediente);

            t.CVenta = venta;
            t.COrden = orden;
            t.CEmpleado = empleado;
            t.CIngrediente = ingrediente;


            return orden_per.Update(t);
        }
    }
}
