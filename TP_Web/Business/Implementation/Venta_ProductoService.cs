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
            return vntprodctRepository.Delete(id);
        }

        public List<Venta_Producto> FindAll()
        {
            return vntprodctRepository.FindAll();
        }

        public Venta_Producto FindById(int? id)
        {
            return vntprodctRepository.FindById(id);
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
            return vntprodctRepository.Update(t);
        }
             
    }
}
