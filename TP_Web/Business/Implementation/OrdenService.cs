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
    public class OrdenService : IOrdenService
    {
        private IOrdenRepository ordenrepo = new OrdenRepository();
        private IVentaRepository ventarepo = new VentaRepository();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Orden> FindAll()
        {
            return ordenrepo.FindAll();
        }

        public Orden FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public Orden FindById(int? id, int? id2)
        {
            return ordenrepo.FindById(id, id2);
        }

        public Orden FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Orden t)
        {
            Venta venta = ventarepo.FindById(t.CVenta.CVenta);
            t.CVenta = venta;

            return ordenrepo.Insert(t);
        }

        public bool Update(Orden t)
        {
            Venta venta = ventarepo.FindById(t.CVenta.CVenta);
            t.CVenta = venta;

            return ordenrepo.Update(t);
        }
    }
    }
}
