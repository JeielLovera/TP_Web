using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Implementation
{
    public class ProductoRepository : IProductoRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Producto> FindAll()
        {
            var productos = new List<Producto>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select p.CProducto,p.NProducto,p.MPrecio, tp.NTipoProducto as NTipoProducto FROM  Producto p, TipoProducto tp where p.CTipoProducto = tp.CTipoProducto", con);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var producto = new Producto();
                            var tipo = new TipoProducto();

                            producto.CProducto = Convert.ToInt32(dr["CProducto"]);
                            producto.NProducto = dr["NProducto"].ToString();
                            producto.MPrecio = Convert.ToSingle(dr["MPrecio"]);

                            tipo.NTipoProducto = dr["NTipoProducto"].ToString();

                            producto.CTipoProducto = tipo;

                            productos.Add(producto);
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception)
            { throw; }

            return productos;
        }

        public Producto FindById(int? id)
        {
            Producto producto = null;


            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select p.CProducto, p.NProducto, p.MPrecio, tp.NTipoProducto as NTipoProducto from Producto p, TipoProducto tp where p.CTipoProducto ='"+id+"'",con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            producto = new Producto();
                            var tp = new TipoProducto();

                            producto.CProducto = Convert.ToInt32(dr["CProducto"]);
                            producto.NProducto = dr["NProducto"].ToString();
                            producto.MPrecio = Convert.ToSingle(dr["MPrecio"]);
                            tp.NTipoProducto = dr["NTipoProducto"].ToString();

                            producto.CTipoProducto = tp;

                        }
                    }
                    con.Close();
                }
            }
            catch(Exception)
            { throw; }
            return producto;
        }

        public bool Insert(Producto t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Producto values (@NProducto, @MPrecio,@NTipoProducto)", con);
                    cmd.Parameters.AddWithValue("@NProducto", t.NProducto);
                    cmd.Parameters.AddWithValue("@MPrecio", t.MPrecio);
                    cmd.Parameters.AddWithValue("@NTipoProducto", t.CTipoProducto.NTipoProducto);

                    cmd.ExecuteNonQuery();
                    rpta = true;
                    con.Close();
                }
            }
            catch(Exception)
            { throw; }

            return rpta;
        }

        public bool Update(Producto t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();

                    var cmd = new SqlCommand("update Producto set NProducto=@Nproducto,MPrecio=@MPrecio, CTipoProducto=@CTipoProducto where CProducto=@CProducto", con);
                    cmd.Parameters.AddWithValue("@CProducto", t.CProducto);
                    cmd.Parameters.AddWithValue("@Nproducto", t.CProducto);
                    cmd.Parameters.AddWithValue("@MPrecio", t.CProducto);
                    cmd.Parameters.AddWithValue("@CTipoProducto", t.CTipoProducto);
                    cmd.ExecuteNonQuery();
                    rpta = true;
                }
            }
            catch(Exception)
            { throw; }
            return rpta;
        }
    }
}
