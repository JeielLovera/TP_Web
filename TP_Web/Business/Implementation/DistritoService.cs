﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;
using Data.Implementation;

namespace Business.Implementation
{
    public class DistritoService : IDistritoService
    {
        private IDistritoRepository distrito = new DistritoRepository();
        public bool Delete(int id)
        {
            return distrito.Delete(id);
        }

        public List<Distrito> FindAll()
        {
            return distrito.FindAll();
        }

        public Distrito FindById(int? id)
        {
            return distrito.FindById(id);
        }
        
        public bool Insert(Distrito t)
        {
            return distrito.Insert(t);
        }

        public bool Update(Distrito t)
        {
            return distrito.Update(t);
        }
    }
}
