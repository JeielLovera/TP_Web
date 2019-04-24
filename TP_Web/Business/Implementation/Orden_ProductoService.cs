﻿using System;
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
        private IOrden_ProductoRepository orden_pro = new Orden_ProductoRepository();
        private IProductoRepository prodctRepository = new ProductoRepository();
        private IVentaRepository ventaRepository = new VentaRepository();
        private IOrdenRepository ordenRepository = new OrdenRepository();
        private IEmpleadoRepository empleadoRepository = new EmpleadoRepository();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Orden_Producto> FindAll()
        {
            return orden_pro.FindAll();
        }

        public Orden_Producto FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public Orden_Producto FindById(int? id, int? id2)
        {
            throw new NotImplementedException();
        }

        public Orden_Producto FindById(int? id, int? id2, int? id3)
        {
            return orden_pro.FindById(id, id2, id3);
        }

        public bool Insert(Orden_Producto t)
        {
            Producto producto = prodctRepository.FindById(t.CProducto.CProducto);
            Venta venta = ventaRepository.FindById(t.CVenta.CVenta);
            Orden orden = ordenRepository.FindById(t.COrden.COrden);
            Empleado empleado = empleadoRepository.FindById(t.CEmpleado.CEmpleado);

            t.CProducto = producto;
            t.CVenta = venta;
            t.COrden = orden;
            t.CEmpleado = empleado;

            return orden_pro.Insert(t);
        }

        public bool Update(Orden_Producto t)
        {
            Producto producto = prodctRepository.FindById(t.CProducto.CProducto);
            Venta venta = ventaRepository.FindById(t.CVenta.CVenta);
            Orden orden = ordenRepository.FindById(t.COrden.COrden);
            Empleado empleado = empleadoRepository.FindById(t.CEmpleado.CEmpleado);

            t.CProducto = producto;
            t.CVenta = venta;
            t.COrden = orden;
            t.CEmpleado = empleado;

            return orden_pro.Update(t);
        }
    }
}
