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
    public class LocalService : ILocalService
    {
        private ILocalRepository LocalRepository= new LocalRepository();
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Local> FindAll()
        {
            return LocalRepository.FindAll();
        }

        public Local FindById(int? id)
        {
            return LocalRepository.FindById(id);
        }

        public bool Insert(Local t)
        {
            return LocalRepository.Insert(t);
        }

        public bool Update(Local t)
        {
            return LocalRepository.Update(t);
        }
    }
}
