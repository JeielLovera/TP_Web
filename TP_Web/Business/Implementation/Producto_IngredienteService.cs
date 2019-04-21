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
    public class Producto_IngredienteService : IProducto_IngredienteRepository
    {
        private IProducto_IngredienteRepository prodctingrdntRepository = new Producto_IngredienteRepository();
        private IProductoRepository prodctRepository = new ProductoRepository();
        private IIngredienteRepository ingrdntRepository = new IngredienteRepository();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Producto_Ingrediente> FindAll()
        {
            return prodctingrdntRepository.FindAll();
        }

        public Producto_Ingrediente FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Producto_Ingrediente t)
        {
            Producto producto = prodctRepository.FindById(t.CProducto.CProducto);
            Ingrediente ingrediente = ingrdntRepository.FindById(t.CIngrediente.CIngrediente);
            t.CProducto = producto;
            t.CIngrediente = ingrediente;
            return prodctingrdntRepository.Insert(t);
        }

        public bool Update(Producto_Ingrediente t)
        {
            Producto producto = prodctRepository.FindById(t.CProducto.CProducto);
            Ingrediente ingrediente = ingrdntRepository.FindById(t.CIngrediente.CIngrediente);
            t.CProducto = producto;
            t.CIngrediente = ingrediente;
            return prodctingrdntRepository.Update(t);
        }

        public Producto_Ingrediente FindById(int? id, int? id2)
        {            
            return prodctingrdntRepository.FindById(id);
        }

        public Producto_Ingrediente FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }
    }
}
