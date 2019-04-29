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
                    var cmd = new SqlCommand("select op.COrden_Producto, op.COrden, o.CVenta, p.NProducto, ep.NEmpleado, op.QOrdenProducto from Orden_Producto op, Producto p, Empleado ep, Orden o where op.CProducto=p.CProducto and op.CEmpleado=ep.CEmpleado and op.COrden=o.COrden", con);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var orden_producto = new Orden_Producto();
                            var orden = new Orden();
                            var venta = new Venta();
                            var producto = new Producto();
                            var empleado = new Empleado();

                            orden_producto.COrden_Producto = Convert.ToInt32(dr["COrden_Producto"]);
                            orden.COrden = Convert.ToInt32(dr["COrden"]);
                            venta.CVenta = Convert.ToInt32(dr["CVenta"]);
                            orden.CVenta = venta;
                            orden_producto.COrden = orden;
                            producto.NProducto = dr["NProducto"].ToString();
                            orden_producto.CProducto = producto;
                            empleado.NEmpleado = dr["NEmpleado"].ToString();
                            orden_producto.CEmpleado = empleado;
                            orden_producto.QOrdenProducto = Convert.ToInt32(dr["QOrdenProducto"]);
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
            Orden_Producto orden_producto = null;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select op.COrden_Producto, op.COrden, o.CVenta, p.NProducto, ep.NEmpleado, op.QOrdenProducto from Orden_Producto op, Producto p, Empleado ep, Orden o where op.CProducto=p.CProducto and op.CEmpleado=ep.CEmpleado and op.COrden=o.COrden and op.COrden_Producto='" + id+"'", con);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            orden_producto = new Orden_Producto();
                            var orden = new Orden();
                            var producto = new Producto();
                            var empleado = new Empleado();

                            orden_producto.COrden_Producto = Convert.ToInt32(dr["COrden_Producto"]);
                            orden.COrden = Convert.ToInt32(dr["COrden"]);
                            orden.CVenta.CVenta = Convert.ToInt32(dr["CVenta"]);
                            orden_producto.COrden = orden;
                            producto.NProducto = dr["NProducto"].ToString();
                            orden_producto.CProducto = producto;
                            empleado.NEmpleado = dr["NEmpleado"].ToString();
                            orden_producto.CEmpleado = empleado;
                            orden_producto.QOrdenProducto = Convert.ToInt32(dr["QOrdenProducto"]);


                        }
                    }
                    con.Close();
                }

            }
            catch (Exception)
            { throw; }

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
                    var cmd = new SqlCommand("insert into Orden_Producto values (@COrden,@CProducto,@CEmpleado,@QOrdenProducto)", con);
                    cmd.Parameters.AddWithValue("@COrden", t.COrden.COrden);
                    cmd.Parameters.AddWithValue("@CProducto", t.CProducto.CProducto);                    
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

                    var cmd = new SqlCommand("update Orden_Producto set CEmpleado=@CEmpleado, QOrdenProducto = @QOrdenProducto where COrden_Producto=@id", con);
                    cmd.Parameters.AddWithValue("@id", t.COrden_Producto);
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

    }
}
