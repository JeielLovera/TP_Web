﻿using System;
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
            throw new NotImplementedException();
        }

        public List<TipoIngrediente> FindAll()
        {
            return tpingredienteRepository.FindAll();
        }

        public TipoIngrediente FindById(int? id)
        {
            return tpingredienteRepository.FindById(id);
        }

        public TipoIngrediente FindById(int? id, int? id2)
        {
            throw new NotImplementedException();
        }

        public TipoIngrediente FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
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
