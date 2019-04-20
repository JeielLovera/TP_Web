using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Entity;
using System.Configuration;

namespace Data.Implementation
{
    public class Venta_ProductoRepository : IVenta_ProductoRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Venta_Producto> FindAll()
        {
            var arr_vntproduct = new List<Venta_Producto>();
            try
            {
                using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select vt.CVenta, vt.CProducto, p.NProducto, vt.QCantidad from Venta_Producto vt, Producto p where vt.CProducto=p.CProducto", con);
                    using(var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ventaproducto = new Venta_Producto();
                            var venta = new Venta();
                            var producto = new Producto();

                            venta.CVenta = Convert.ToInt32(dr["CVenta"]);
                            ventaproducto.CVenta = venta;
                            producto.CProducto = Convert.ToInt32(dr["CProducto"]);
                            producto.NProducto = dr["NProducto"].ToString();
                            ventaproducto.CProducto = producto;
                            ventaproducto.QCantidad = Convert.ToInt32(dr["QCantidada"]);
                            arr_vntproduct.Add(ventaproducto);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return arr_vntproduct;
        }

        public Venta_Producto FindById(int? id)
        {
            Venta_Producto ventaproducto = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select vt.CVenta, vt.CProducto, p.NProducto, vt.QCantidad from Venta_Producto vt, Producto p where vt.CProducto=p.CProducto and vt.CVenta='"+id+"'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ventaproducto = new Venta_Producto();
                            var venta = new Venta();
                            var producto = new Producto();

                            venta.CVenta = Convert.ToInt32(dr["CVenta"]);
                            ventaproducto.CVenta = venta;
                            producto.CProducto = Convert.ToInt32(dr["CProducto"]);
                            producto.NProducto = dr["NProducto"].ToString();
                            ventaproducto.CProducto = producto;
                            ventaproducto.QCantidad = Convert.ToInt32(dr["QCantidada"]);
                            
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception)
            {
                throw;
            }
            return ventaproducto;
        }

        public bool Insert(Venta_Producto t)
        {
            bool rpta = false;
            try
            {
                using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Venta_Producto values (@cproducto, @cventa,@cantidad)", con);
                    cmd.Parameters.AddWithValue("@cproducto", t.CProducto.CProducto);
                    cmd.Parameters.AddWithValue("@cventa", t.CVenta.CVenta);
                    cmd.Parameters.AddWithValue("@cantidad", t.QCantidad);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    rpta = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rpta;
        }

        public bool Update(Venta_Producto t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("update VentaProducto set QCantidad=@cantidad where CProducto=@cproducto and CVenta=@cventa", con);
                    cmd.Parameters.AddWithValue("@cproducto", t.CProducto.CProducto);
                    cmd.Parameters.AddWithValue("@cventa", t.CVenta.CVenta);
                    cmd.Parameters.AddWithValue("@cantidad", t.QCantidad);
                    con.Close();
                    rpta = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rpta;
        }
    }
}
