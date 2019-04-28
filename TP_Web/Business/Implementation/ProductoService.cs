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
    public class ProductoService : IProductoService
    {
        private IProductoRepository ProductoRepository = new ProductoRepository();
        private ITipoProductoRepository tipoProductoRepository = new TipoProductoRepository();
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Producto> FindAll()
        {
            return ProductoRepository.FindAll();
        }

        public Producto FindById(int? id)
        {
            return ProductoRepository.FindById(id);
        }


        public bool Insert(Producto t)
        {
            TipoProducto tipoproducto = tipoProductoRepository.FindById(t.CTipoProducto.CTipoProducto);
            t.CTipoProducto = tipoproducto;

            return ProductoRepository.Insert(t);
        }

        public bool Update(Producto t)
        {
            TipoProducto tipoproducto = tipoProductoRepository.FindById(t.CTipoProducto.CTipoProducto);
            t.CTipoProducto = tipoproducto;

            return ProductoRepository.Update(t);
        }
    }
}
