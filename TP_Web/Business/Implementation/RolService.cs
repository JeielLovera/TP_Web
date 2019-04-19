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
    public class RolService : IRolService
    {
        private IRolRepository RolRepository = new RolRepository();
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Rol> FindAll()
        {
            return RolRepository.FindAll();
        }

        public Rol FindById(int? id)
        {
            return RolRepository.FindById(id);
        }

        public bool Insert(Rol t)
        {
            return RolRepository.Insert(t);
        }

        public bool Update(Rol t)
        {
            return RolRepository.Update(t);
        }
    }
}
