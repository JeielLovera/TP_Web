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
    public class MesaRepository : IMesaRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Mesa> FindAll()
        {
            var mesas = new List<Mesa>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from Mesa", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            var mesa = new Mesa();
                            var local = new Local();
                            mesa.CMesa = Convert.ToInt32(dr["CMesa"]);
                            mesa.NumMesa = Convert.ToInt32(dr["NumMesa"]);
                            mesa.QCapacidad = Convert.ToInt32(dr["QCapacidad"]);
                            local.CLocal= Convert.ToInt32(dr["CLocal"]);

                            mesa.CLocal = local;
                            mesas.Add(mesa);

                        }
                    }
                    con.Close();
                }
            }
            catch(Exception)
            {
                throw;
            }
            return mesas;
        }

        public Mesa FindById(int? id)
        {
            Mesa mesa = null;

            try
            {
                using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();

                    var cmd = new SqlCommand("select * from  Mesa where CMesa='" + id + "'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            mesa = new Mesa();
                            var local = new Local();
                            mesa.CMesa = Convert.ToInt32(dr["CMesa"]);
                            mesa.NumMesa = Convert.ToInt32(dr["NumMesa"]);
                            mesa.QCapacidad = Convert.ToInt32(dr["QCapacidad"]);
                            local.CLocal = Convert.ToInt32(dr["CLocal"]);

                            mesa.CLocal = local;
                        }
                    }
                    con.Close();
                }
            }
            catch(Exception)
            { throw; }
            return mesa;
        }

        public bool Insert(Mesa t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Mesa values (@NumMesa, @QCapacidad,@CLocal)", con);
                    cmd.Parameters.AddWithValue("@NumMesa", t.NumMesa);
                    cmd.Parameters.AddWithValue("@QCapacidad", t.QCapacidad);
                    cmd.Parameters.AddWithValue("@CLocal", t.CLocal);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    rpta = true;

                }
            }
            catch(Exception)
            {
                throw;
            }

            return rpta;
        }

        public bool Update(Mesa t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("update Mesa set NumMesa=@NumMesa, QCapacidad=@QCapacidad, CLocal=@CLocal where CMesa=@CMesa)", con);
                    cmd.Parameters.AddWithValue("@CMesa", t.CMesa);
                    cmd.Parameters.AddWithValue("@NumMesa", t.NumMesa);
                    cmd.Parameters.AddWithValue("@QCapacidad", t.QCapacidad);
                    cmd.Parameters.AddWithValue("@CLocal", t.CLocal);

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
