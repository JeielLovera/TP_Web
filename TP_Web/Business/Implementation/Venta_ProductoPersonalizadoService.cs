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
    public class Venta_ProductoPersonalizadoService : IVenta_ProductoPersonalizadoService
    {
        private IVenta_ProductoPersonalizadoRepository venta_pro_repo = new Venta_ProductoPersonalizadoRepository();
        private IVentaRepository ventaRepository = new VentaRepository();
        private IIngredienteRepository ingredienteRepository = new IngredienteRepository();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Venta_ProductoPersonalizado> FindAll()
        {
            return venta_pro_repo.FindAll();
        }

        public Venta_ProductoPersonalizado FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public Venta_ProductoPersonalizado FindById(int? id, int? id2)
        {
            return venta_pro_repo.FindById(id, id2);
        }

        public Venta_ProductoPersonalizado FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Venta_ProductoPersonalizado t)
        {
            Venta venta = ventaRepository.FindById(t.CVenta.CVenta);
            Ingrediente ingrediente = ingredienteRepository.FindById(t.CIngrediente.CIngrediente);
            t.CVenta = venta;
            t.CIngrediente = ingrediente;

            return venta_pro_repo.Insert(t);
        }

        public bool Update(Venta_ProductoPersonalizado t)
        {
            Venta venta = ventaRepository.FindById(t.CVenta.CVenta);
            Ingrediente ingrediente = ingredienteRepository.FindById(t.CIngrediente.CIngrediente);
            t.CVenta = venta;
            t.CIngrediente = ingrediente;

            return venta_pro_repo.Update(t);
        }
    }
}
