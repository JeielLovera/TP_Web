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
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Empleado> FindAll()
        {
            return empleadorepo.FindAll();
        }

        public Empleado FindById(int? id)
        {
            return empleadorepo.FindById(id);
        }

        public Empleado FindById(int? id, int? id2)
        {
            throw new NotImplementedException();
        }

        public Empleado FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Empleado t)
        {
            return empleadorepo.Insert(t);
        }

        public bool Update(Empleado t)
        {
            return empleadorepo.Update(t);
        }
    }
}
