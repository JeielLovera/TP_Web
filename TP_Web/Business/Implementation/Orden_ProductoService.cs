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
    public class Orden_ProductoService : IOrden_ProductoService
    {
        private IOrden_ProductoRepository orden = new Orden_ProductoRepositorycs(); 
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order_Producto> FindAll()
        {
            return orden.FindAll();
        }

        public Order_Producto FindById(int? id, int id2)
        {
            return orden.FindById(id,id2);
        }

        public bool Insert(Order_Producto t)
        {
            return orden.Insert(t);
        }

        public bool Update(Order_Producto t)
        {
            return orden.Update(t);
        }
    }
}
