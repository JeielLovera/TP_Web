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
    public class DistritoRepository : IDistritoRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("delete from Distrito where CDistrito='" + id + "'", con);
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

        public List<Entity.Distrito> FindAll()
        {
            var distritos = new List<Distrito>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select CDistrito, NDistrito from Distrito", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var distrito = new Distrito();
                            distrito.CDistrito = Convert.ToInt32(dr["CDistrito"]);
                            distrito.NDistrito = dr["NDistrito"].ToString();

                            distritos.Add(distrito);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return distritos;
        }

        public Entity.Distrito FindById(int? id)
        {
            Distrito distrito = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select CDistrito, NDistrito from Distrito where CDistrito='"+ id +"'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            distrito = new Distrito();
                            distrito.CDistrito = Convert.ToInt32(dr["CDistrito"]);
                            distrito.NDistrito = dr["NDistrito"].ToString();
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return distrito;
        }
               

        public bool Insert(Entity.Distrito t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Distrito values(@NDistrito)", con);

                    cmd.Parameters.AddWithValue("@NDistrito", t.NDistrito);
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

        public bool Update(Entity.Distrito t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("update Distrito set NDistrito=@NDistrito where CDistrito=@CDistrito", con);

                    cmd.Parameters.AddWithValue("@CDistrito", t.CDistrito);
                    cmd.Parameters.AddWithValue("@NDistrito", t.NDistrito);
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
