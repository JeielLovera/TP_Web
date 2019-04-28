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
    public class DireccionService : IDireccionService
    {
        private IDireccionRepository calle_rep = new DireccionRepository();
        private IDistritoRepository distritoRepository = new DistritoRepository();
        private ITipo_DireccionRepository tipo_DireccionRepository = new Tipo_DireccionRepository();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Direccion> FindAll()
        {
            return calle_rep.FindAll();
        }

        public Direccion FindById(int? id)
        {
            return calle_rep.FindById(id);
        }
              

        public bool Insert(Direccion t)
        {
            Distrito distrito = distritoRepository.FindById(t.CDistrito.CDistrito);
            Tipo_Direccion tipo = tipo_DireccionRepository.FindById(t.CTipoDireccion.CTipo);

            t.CDistrito = distrito;
            t.CTipoDireccion = tipo;

            return calle_rep.Insert(t);
        }

        public bool Update(Direccion t)
        {
            Distrito distrito = distritoRepository.FindById(t.CDistrito.CDistrito);
            Tipo_Direccion tipo = tipo_DireccionRepository.FindById(t.CTipoDireccion.CTipo);

            t.CDistrito = distrito;
            t.CTipoDireccion = tipo;

            return calle_rep.Update(t);
        }
    }
}
