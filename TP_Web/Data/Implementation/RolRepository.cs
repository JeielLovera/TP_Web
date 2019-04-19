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
    public class RolRepository : IRolRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Rol> FindAll()
        {
            List<Rol> Roles = new List<Rol>();
            
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                { 
                    con.Open();
                    var cmd = new SqlCommand("select * from Rol", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var rol = new Rol();
                            rol.CRol = Convert.ToInt32(dr["CRol"]);
                            rol.NRol = dr["NRol"].ToString();

                            Roles.Add(rol);

                        }
                    }
                    con.Close();
                }

            }
            catch(Exception)
            { throw; }
            return Roles;  
        }

        public Rol FindById(int? id)
        {
            Rol rol = null;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from Rol where CRol='"+id+"'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            rol = new Rol();
                            rol.CRol = Convert.ToInt32(dr["CRol"]);
                            rol.NRol = dr["NRol"].ToString();
                        }
                    }
                    con.Close();
                }
            }
            catch(Exception)
            { throw; }
            return rol;
        }

        public bool Insert(Rol t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Rol values (@cRol, @nRol)", con);
                   
                    cmd.Parameters.AddWithValue("@nRol", t.NRol);

                    cmd.ExecuteNonQuery();
                    rpta = true;
                }
            }
            catch(Exception)
            { throw; }

            return rpta;
        }

        public bool Update(Rol t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BS_Piazza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("update Rol set NRol=@nRol where CRol=@cRol", con);

                    cmd.Parameters.AddWithValue("@cRol", t.CRol);
                    cmd.Parameters.AddWithValue("@nRol", t.NRol);

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
