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
    public class Orden_ProductoPersonalizadoService : IOrden_ProductoPersonalizadoService
    {
        private IOrden_ProductoPersonalizadoRepository orden_per = new Orden_ProductoPersonalizadoRepository();
        private IOrdenRepository ordenRepository = new OrdenRepository();
        private IEmpleadoRepository empleadoRepository = new EmpleadoRepository();
        private IIngredienteRepository ingredienteRepository = new IngredienteRepository();

        public bool Delete(int id)
        {
            return orden_per.Delete(id);
        }

        public List<Orden_ProductoPersonalizado> FindAll()
        {
           return orden_per.FindAll();
        }

        public Orden_ProductoPersonalizado FindById(int? id)
        {
            return orden_per.FindById(id);
        }
              
        public bool Insert(Orden_ProductoPersonalizado t)
        {
            Orden orden = ordenRepository.FindById(t.COrden.COrden);
            Empleado empleado = empleadoRepository.FindById(t.CEmpleado.CEmpleado);
            Ingrediente ingrediente = ingredienteRepository.FindById(t.CIngrediente.CIngrediente);
            t.COrden = orden;
            t.CEmpleado = empleado;
            t.CIngrediente = ingrediente;
            
            return  orden_per.Insert(t);
        }

        public bool Update(Orden_ProductoPersonalizado t)
        {
            Orden orden = ordenRepository.FindById(t.COrden.COrden);
            Empleado empleado = empleadoRepository.FindById(t.CEmpleado.CEmpleado);
            Ingrediente ingrediente = ingredienteRepository.FindById(t.CIngrediente.CIngrediente);
            t.COrden = orden;
            t.CEmpleado = empleado;
            t.CIngrediente = ingrediente;

            return orden_per.Update(t);
        }
    }
}
