using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Business.Implementation
{
    public class Orden_ProductoPerzonalizadoService : IOrden_ProductoPerzonalizadoService
    {
        private IOrden_ProductoPerzonalizadoService orden = new Orden_ProductoPerzonalizadoService();
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Orden_ProductoPerzonalizado> FindAll()
        {
            return orden.FindAll();
        }

        public Orden_ProductoPerzonalizado FindById(int? id, int id2)
        {
            return orden.FindById(id,id2);
        }

        public bool Insert(Orden_ProductoPerzonalizado t)
        {
            return orden.Insert(t);
        }

        public bool Update(Orden_ProductoPerzonalizado t)
        {
            return orden.Update(t);
        }
    }
}
