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
    public class TipoIngredienteService : ITipoIngredienteService
    {
        private ITipoIngredienteRepository tpingredienteRepository = new TipoIngredienteRepository();
        public bool Delete(int id)
        {
            return tpingredienteRepository.Delete(id);
        }

        public List<TipoIngrediente> FindAll()
        {
            return tpingredienteRepository.FindAll();
        }

        public TipoIngrediente FindById(int? id)
        {
            return tpingredienteRepository.FindById(id);
        }
      
        public bool Insert(TipoIngrediente t)
        {
            return tpingredienteRepository.Insert(t);
        }

        public bool Update(TipoIngrediente t)
        {
            return tpingredienteRepository.Update(t);
        }
    }
}
