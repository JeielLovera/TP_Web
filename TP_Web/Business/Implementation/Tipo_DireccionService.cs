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
    public class Tipo_DireccionService : ITipo_DireccionService
    {
        private ITipo_DireccionRepository direccion = new Tipo_DireccionRepository();
        public bool Delete(int id)
        {
            return direccion.Delete(id);
        }

        public List<Tipo_Direccion> FindAll()
        {
            return direccion.FindAll();
        }

        public Tipo_Direccion FindById(int? id)
        {
            return direccion.FindById(id);
        }
               

        public bool Insert(Tipo_Direccion t)
        {
            return direccion.Insert(t);
        }

        public bool Update(Tipo_Direccion t)
        {
            return direccion.Update(t);
        }
    }
}
