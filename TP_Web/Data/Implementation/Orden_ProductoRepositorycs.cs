using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Implementation
{
    public class Orden_ProductoRepositorycs : IOrden_ProductoRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order_Producto> FindAll()
        {
            var ordenes = new List<Order_Producto>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select op.COrden, p.CProducto,p.NProducto,p.MPrecioFROM  Orden_Producto op, Producto p where op.CProducto = p.CProducto", con);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var orden_producto = new Order_Producto();

                            var orden = new Orden();
                            var producto = new Producto();
                            var empleado = new Empleado();
                            var venta = new Venta();

                            orden_producto.QOrdenProducto = Convert.ToInt32(dr["QOrdenProducto"]);
                            orden_producto.CEmpleado = empleado;
                            orden_producto.COrden = orden;
                            orden_producto.CVenta = venta;
                            orden_producto.CProducto = producto;

                            ordenes.Add(orden_producto);
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception)
            { throw; }

            return ordenes;
        }

        public Order_Producto FindById(int? id, int id2)
        {
            Order_Producto orden_producto = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select op.CEmpleado, op.COrden, op.CProducto, op.CVenta from Orden_Producto op where op.COrden='" + id + "' op.CVenta='" + id2 + "'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var orden = new Orden();
                            var producto = new Producto();
                            var empleado = new Empleado();
                            var venta = new Venta();

                            orden_producto.QOrdenProducto = Convert.ToInt32(dr["QOrdenProducto"]);
                            orden_producto.CEmpleado = empleado;
                            orden_producto.COrden = orden;
                            orden_producto.CVenta = venta;
                            orden_producto.CProducto = producto;

                        }
                    }
                    con.Close();
                }

            }
            catch (Exception)
            {
                throw;
            }
            return orden_producto;
        }

        public Order_Producto FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public Order_Producto FindById(int? id, int? id2)
        {
            throw new NotImplementedException();
        }

        public Order_Producto FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Order_Producto t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Producto values (@CProducto, @CVenta,@COrden,@CEmpleado,@QOrdenProducto)", con);
                    cmd.Parameters.AddWithValue("@CProducto", t.CProducto);
                    cmd.Parameters.AddWithValue("@CVenta", t.CVenta);
                    cmd.Parameters.AddWithValue("@COrden", t.COrden);
                    cmd.Parameters.AddWithValue("@CEmpleado", t.CEmpleado);
                    cmd.Parameters.AddWithValue("@QOrdenProducto", t.QOrdenProducto);

                    cmd.ExecuteNonQuery();
                    rpta = true;
                    con.Close();
                }
            }
            catch (Exception)
            { throw; }

            return rpta;
        }

        public bool Update(Order_Producto t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();

                    var cmd = new SqlCommand("update Producto set CEmpleado=@CEmpleado,CVenta=@CVenta, COrden=@COrden, QOrdenProducto =@QOrdenProducto where CProducto=@CProducto", con);
                    cmd.Parameters.AddWithValue("@CProducto", t.CProducto);
                    cmd.Parameters.AddWithValue("@CVenta", t.CVenta);
                    cmd.Parameters.AddWithValue("@COrden", t.COrden);
                    cmd.Parameters.AddWithValue("@CEmpleado", t.CEmpleado);
                    cmd.Parameters.AddWithValue("@QOrdenProducto", t.QOrdenProducto);
                    cmd.ExecuteNonQuery();
                    rpta = true;
                }
            }
            catch (Exception)
            { throw; }
            return rpta;
        }
    }
}
