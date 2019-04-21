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
    public class MesaService : IMesaService
    {
        private IMesaRepository mesaRepository = new MesaRepository();
        private ILocalRepository localRepository = new LocalRepository();
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Mesa> FindAll()
        {
            return mesaRepository.FindAll();
        }

        public Mesa FindById(int? id)
        {
            return mesaRepository.FindById(id);
        }
        public Mesa FindById(int? id, int? id2)
        {
            throw new NotImplementedException();
        }

        public Mesa FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }
        public bool Insert(Mesa t)
        {
            Local local = localRepository.FindById(t.CLocal.CLocal);
            t.CLocal = local;

            return mesaRepository.Insert(t);
        }

        public bool Update(Mesa t)
        {
            return mesaRepository.Update(t);
        }

        
    }
}
