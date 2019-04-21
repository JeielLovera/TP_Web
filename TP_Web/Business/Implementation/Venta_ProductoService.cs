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
    public class Venta_ProductoService : IVenta_ProductoService
    {
        private IVenta_ProductoRepository vntprodctRepository = new Venta_ProductoRepository();
        private IVentaRepository ventaRepository = new VentaRepository();
        private IProductoRepository productoRepository = new ProductoRepository();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Venta_Producto> FindAll()
        {
            return vntprodctRepository.FindAll();
        }

        public Venta_Producto FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Venta_Producto t)
        {
            Venta venta = ventaRepository.FindById(t.CVenta.CVenta);
            Producto producto = productoRepository.FindById(t.CProducto.CProducto);
            t.CProducto = producto;
            t.CVenta = venta;
            return vntprodctRepository.Insert(t);
        }

        public bool Update(Venta_Producto t)
        {
            Venta venta = ventaRepository.FindById(t.CVenta.CVenta);
            Producto producto = productoRepository.FindById(t.CProducto.CProducto);
            t.CProducto = producto;
            t.CVenta = venta;
            return vntprodctRepository.Insert(t);
        }

        public Venta_Producto FindById(int? id, int? id2)
        {
            return vntprodctRepository.FindById(id,id2);
        }

        public Venta_Producto FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }
    }
}
