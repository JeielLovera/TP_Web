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
    public class Calle_Avenida_JironcsService : ICalle_Avenida_JironcsService
    {
        private ICalle_Avenida_JironRepository calle_rep = new Calle_Avenida_JironcsRepository();
        private IDistritoRepository distritoRepository = new DistritoRepository();
        private ITipo_DireccionRepository tipo_DireccionRepository = new Tipo_DireccionRepository();
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Calle_Avenida_Jiron> FindAll()
        {
            return calle_rep.FindAll();
        }

        public Calle_Avenida_Jiron FindById(int? id)
        {
            return calle_rep.FindById(id);
        }

        public Calle_Avenida_Jiron FindById(int? id, int? id2)
        {
            throw new NotImplementedException();
        }

        public Calle_Avenida_Jiron FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Calle_Avenida_Jiron t)
        {
            Distrito distrito = distritoRepository.FindById(t.CDistrito.CDistrito);
            Tipo_Direccion tipo = tipo_DireccionRepository.FindById(t.CTipo.CTipo);

            t.CDistrito = distrito;
            t.CTipo = tipo;

            return calle_rep.Insert(t);
        }

        public bool Update(Calle_Avenida_Jiron t)
        {
            throw new NotImplementedException();
        }
    }
}
