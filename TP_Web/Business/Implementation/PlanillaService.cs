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
    public class PlanillaService : IPlanillaService
    {
        private IPlanillaRepository planillarepo = new PlanillaRepository();
        private IEmpleadoRepository empleadorepo = new EmpleadoRepository();
        private IRolRepository rolrepo = new RolRepository();
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Planilla> FindAll()
        {
            return planillarepo.FindAll();
        }

        public Planilla FindById(int? id)
        {
            return planillarepo.FindById(id);
        }

        public bool Insert(Planilla t)
        {
            Empleado empleado = empleadorepo.FindById(t.CEmpleado.CEmpleado);
            Rol rol = rolrepo.FindById(t.CRol.CRol);

            t.CEmpleado = empleado;
            t.CRol = rol;
            return planillarepo.Insert(t);
        }

        public bool Update(Planilla t)
        {
            return planillarepo.Update(t);
        }
    }
}
