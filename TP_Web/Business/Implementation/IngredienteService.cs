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
    public class IngredienteService : IIngredienteService
    {
        private IIngredienteRepository ingredienteRepository = new IngredienteRepository();
        private ITipoIngredienteRepository tpingredienteRepository = new TipoIngredienteRepository();

        public bool Delete(int id)
        {
            return ingredienteRepository.Delete(id);
        }

        public List<Ingrediente> FindAll()
        {
            return ingredienteRepository.FindAll();
        }

        public Ingrediente FindById(int? id)
        {
            return ingredienteRepository.FindById(id);

        }
        
        public bool Insert(Ingrediente t)
        {
            TipoIngrediente tpingrediente = tpingredienteRepository.FindById(t.CTipoIngrediente.CTipoIngrediente);
            t.CTipoIngrediente = tpingrediente;
            return ingredienteRepository.Insert(t);

        }

        public bool Update(Ingrediente t)
        {
            TipoIngrediente tpingrediente = tpingredienteRepository.FindById(t.CTipoIngrediente.CTipoIngrediente);
            t.CTipoIngrediente = tpingrediente;
            return ingredienteRepository.Update(t);
        }
    }
}
