using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using Entity;
using System.Configuration;

namespace Data.Implementation
{
    public class LocalRepository : ILocalRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Local> FindAll()
        {
            var locales = new List<Local>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from Local", con);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var local = new Local();

                            local.CLocal = Convert.ToInt32(dr["CLocal"]);
                            local.TDireccionLocal = dr["TDireccionLocal"].ToString();
                            local.NumTelefono = Convert.ToInt32(dr["NumTelefono"]);
                        }
                    }
                    con.Close();
                }
            }
            catch(Exception)
            { throw; }
            return locales;
        }

        public Local FindById(int? id)
        {
            Local local = null;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from Local where CLocal='"+id+"'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            local.CLocal = Convert.ToInt32(dr["CLocal"]);
                            local.TDireccionLocal = dr["TDireccionLocal"].ToString();
                            local.NumTelefono = Convert.ToInt32(dr["NumTelefono"]);
                        }
                    }
                    con.Close();
                }
            }
            catch(Exception)
            {
                throw;
            }

            return local;
        }

        public Local FindById(int? id, int? id2)
        {
            throw new NotImplementedException();
        }

        public Local FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Local t)
        {
            bool rpta=false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Local values(@tdireccion,@numtelefono)", con);
                    cmd.Parameters.AddWithValue("@tdireccion", t.TDireccionLocal);
                    cmd.Parameters.AddWithValue("@numtelefono", t.NumTelefono);

                    cmd.ExecuteNonQuery();

                    rpta = true;
                    con.Close();
                }
            }
            catch(Exception)
            { throw; }
            return rpta;
        }

        public bool Update(Local t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("update Local set TDireccionLocal=@tdireccion,NumTelefono=@numtelefono where CLocal=@cLocal", con);
                    cmd.Parameters.AddWithValue("@cLocal", t.CLocal);
                    cmd.Parameters.AddWithValue("@tdireccion", t.TDireccionLocal);
                    cmd.Parameters.AddWithValue("@numtelefono", t.NumTelefono);

                    cmd.ExecuteNonQuery();
                    rpta = true;
                    con.Close();
                }
            }
            catch(Exception)
            {
                throw;
            }
            return rpta;
        }
    }
}
