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
    public class Orden_ProductoRepository : IOrden_ProductoRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Orden_Producto> FindAll()
        {
            var ordenes = new List<Orden_Producto>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from Orden_Producto", con);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var orden_producto = new Orden_Producto();
                            var orden = new Orden();
                            var producto = new Producto();
                            var empleado = new Empleado();
                            var venta = new Venta();

                            orden_producto.QOrdenProducto = Convert.ToInt32(dr["QOrdenProducto"]);
                            empleado.CEmpleado = Convert.ToInt32(dr["CEmpleado"]);
                            orden_producto.CEmpleado = empleado;
                            orden.COrden = Convert.ToInt32(dr["COrden"]);
                            orden_producto.COrden = orden;
                            venta.CVenta = Convert.ToInt32(dr["CVenta"]);
                            orden_producto.CVenta = venta;
                            producto.CProducto = Convert.ToInt32(dr["CProducto"]);
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


        public Orden_Producto FindById(int? id)
        {
            throw new NotImplementedException();
        }


        public Orden_Producto FindById(int? id, int? id2, int? id3)
        {
            Orden_Producto orden_producto = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from Orden_Producto where COrden='" + id + "' and CVenta='" + id2 + "' and CIngrediente='" + id3 + "'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            orden_producto = new Orden_Producto();
                            var orden = new Orden();
                            var producto = new Producto();
                            var empleado = new Empleado();
                            var venta = new Venta();

                            orden_producto.QOrdenProducto = Convert.ToInt32(dr["QOrdenProducto"]);
                            empleado.CEmpleado = Convert.ToInt32(dr["CEmpleado"]);
                            orden_producto.CEmpleado = empleado;
                            orden.COrden = Convert.ToInt32(dr["COrden"]);
                            orden_producto.COrden = orden;
                            venta.CVenta = Convert.ToInt32(dr["CVenta"]);
                            orden_producto.CVenta = venta;
                            producto.CProducto = Convert.ToInt32(dr["CProducto"]);
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

        public bool Insert(Orden_Producto t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Producto values (@CProducto, @CVenta,@COrden,@CEmpleado,@QOrdenProducto)", con);
                    cmd.Parameters.AddWithValue("@CProducto", t.CProducto.CProducto);
                    cmd.Parameters.AddWithValue("@CVenta", t.CVenta.CVenta);
                    cmd.Parameters.AddWithValue("@COrden", t.COrden.COrden);
                    cmd.Parameters.AddWithValue("@CEmpleado", t.CEmpleado.CEmpleado);
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

        public bool Update(Orden_Producto t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();

                    var cmd = new SqlCommand("update Orden_Producto set CEmpleado=@CEmpleado, QOrdenProducto = @QOrdenProducto where CProducto=@CProducto and CVenta=@CVenta and COrden=@COrden", con);
                    cmd.Parameters.AddWithValue("@CProducto", t.CProducto.CProducto);
                    cmd.Parameters.AddWithValue("@CVenta", t.CVenta.CVenta);
                    cmd.Parameters.AddWithValue("@COrden", t.COrden.COrden);
                    cmd.Parameters.AddWithValue("@CEmpleado", t.CEmpleado.CEmpleado);
                    cmd.Parameters.AddWithValue("@QOrdenProducto", t.QOrdenProducto);
                    cmd.ExecuteNonQuery();
                    rpta = true;
                }
            }
            catch (Exception)
            { throw; }
            return rpta;
        }

        public Orden_Producto FindById(int? id, int? id2)
        {
            throw new NotImplementedException();
        }
    }
}
