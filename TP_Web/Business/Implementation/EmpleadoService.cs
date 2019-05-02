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
    public class EmpleadoService : IEmpleadoService
    {
        IEmpleadoRepository empleadorepo = new EmpleadoRepository();
        IRolRepository rolReposotory = new RolRepository();
        IEmpleadoRepository jefeRepository = new EmpleadoRepository();
        public bool Delete(int id)
        {
            return empleadorepo.Delete(id);
        }

        public List<Empleado> FindAll()
        {
            return empleadorepo.FindAll();
        }

        public Empleado FindById(int? id)
        {
            return empleadorepo.FindById(id);
        }
               
        public bool Insert(Empleado t)
        {
            Empleado jefe = jefeRepository.FindById(t.CJefe.CEmpleado);
            t.CJefe = jefe;
            Rol rol = rolReposotory.FindById(t.CRol.CRol);
            t.CRol = rol;
            return empleadorepo.Insert(t);
        }

        public bool Update(Empleado t)
        {
            Empleado jefe = jefeRepository.FindById(t.CJefe.CEmpleado);
            t.CJefe = jefe;
            Rol rol = rolReposotory.FindById(t.CRol.CRol);
            t.CRol = rol;
            return empleadorepo.Update(t);
        }
    }
}
