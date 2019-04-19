using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Entity;
using System.Configuration;

namespace Data.Implementation
{
    public class TipoProductoRepository : ITipoProductoRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TipoProducto> FindAll()
        {
            var tipos = new List<TipoProducto>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select*from TipoProducto", con);
                    using (var dr=cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var tpproducto = new TipoProducto();
                            tpproducto.CTipoProducto = Convert.ToInt32(dr["CTipoProducto"]);
                            tpproducto.NTipoProducto = dr["NTipoProducto"].ToString();
                            tpproducto.CSubTipoProducto = Convert.ToInt32(dr["CSubTipoProducto"]);
                            tipos.Add(tpproducto);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipos;

        }

        public TipoProducto FindById(int? id)
        {
            TipoProducto tpproducto = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString())) 
                {
                    con.Open();
                    var cmd = new SqlCommand("select*from TipoProducto where CTipoProducto='" + id + "'", con);
                    using (var dr=cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            tpproducto = new TipoProducto();
                            tpproducto.CTipoProducto = Convert.ToInt32(dr["CTipoProducto"]);
                            tpproducto.NTipoProducto = dr["NTipoProducto"].ToString();
                            tpproducto.CSubTipoProducto = Convert.ToInt32(dr["CSubTipoProducto"]);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return tpproducto;
        }

        public bool Insert(TipoProducto t)
        {
            bool rpta = false;
            try
            {
                using (var con=new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into TipoProducto values(@nombre,@subid)", con);
                    cmd.Parameters.AddWithValue("@nombre", t.NTipoProducto);
                    cmd.Parameters.AddWithValue("@subid", t.CSubTipoProducto);
                    cmd.ExecuteNonQuery();
                    rpta = true;
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rpta;
        }

        public bool Update(TipoProducto t)
        {
            bool rpta = false;
            try
            {
                using (var con=new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("update TipoProducto set NTipoProducto=@nombre, CSubTipoProducto=@subid where CTipoProducto=@id", con);
                    cmd.Parameters.AddWithValue("@id", t.CTipoProducto);
                    cmd.Parameters.AddWithValue("@nombre", t.NTipoProducto);
                    cmd.Parameters.AddWithValue("@subid", t.CSubTipoProducto);
                    cmd.ExecuteNonQuery();
                    rpta = true;
                    con.Close();
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
