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
    public class TipoIngredienteRepository : ITipoIngredienteRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TipoIngrediente> FindAll()
        {
            var tipos = new List<TipoIngrediente>();
            try
            {
                using (var con=new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select*from TipoIngrediente", con);
                    using (var dr=cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var tpingrediente = new TipoIngrediente();
                            tpingrediente.CTipoIngrediente = Convert.ToInt32(dr["CTipoIngrediente"]);
                            tpingrediente.NTipoIngrediente = dr["NTipoIngrediente"].ToString();
                            tipos.Add(tpingrediente);
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

        public TipoIngrediente FindById(int? id)
        {
            TipoIngrediente tpingrediente = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select*from TipoIngrediente where CTipoIngrediente='" + id + "'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            tpingrediente = new TipoIngrediente();
                            tpingrediente.CTipoIngrediente = Convert.ToInt32(dr["CTipoIngrediente"]);
                            tpingrediente.NTipoIngrediente = dr["NTipoIngrediente"].ToString();
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return tpingrediente;
        }

        public TipoIngrediente FindById(int? id, int? id2)
        {
            throw new NotImplementedException();
        }

        public TipoIngrediente FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }

        public bool Insert(TipoIngrediente t)
        {
            bool rpta = false;
            try
            {
                using (var con=new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into TipoIngrediente values(@nombre)", con);
                    cmd.Parameters.AddWithValue("@nombre", t.NTipoIngrediente);
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

        public bool Update(TipoIngrediente t)
        {
            bool rpta = false;
            try
            {
                using (var con=new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("update TipoIngrediente set NTipoIngrediente=@nombre where CTipoIngrediente=@id", con);
                    cmd.Parameters.AddWithValue("@id", t.CTipoIngrediente);
                    cmd.Parameters.AddWithValue("@nombre", t.NTipoIngrediente);
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
    }
}
