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
    public class TipoProductoService : ITipoProductoService
    {
        private ITipoProductoRepository tpproductoRepository = new TipoProductoRepository();
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TipoProducto> FindAll()
        {
            return tpproductoRepository.FindAll();
        }

        public TipoProducto FindById(int? id)
        {
            return tpproductoRepository.FindById(id);
        }

        public bool Insert(TipoProducto t)
        {
            return tpproductoRepository.Insert(t);
        }

        public bool Update(TipoProducto t)
        {
            return tpproductoRepository.Update(t);
        }
        
    }
}
