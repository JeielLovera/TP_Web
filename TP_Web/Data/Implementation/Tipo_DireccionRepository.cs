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
    public class Tipo_DireccionRepository : ITipo_DireccionRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Entity.Tipo_Direccion> FindAll()
        {
            var direcciones = new List<Tipo_Direccion>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from TipoDireccion", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var direccion = new Tipo_Direccion();
                            direccion.CTipo = Convert.ToInt32(dr["CTipoDireccion"]);
                            direccion.NTipo = Convert.ToString(dr["NTipoDireccion"]);

                            direcciones.Add(direccion);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return direcciones;
        }

        public Entity.Tipo_Direccion FindById(int? id)
        {
            Tipo_Direccion direccion = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from Tipo_Direccion where CTipo='" + id + "'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        { 
                            direccion.CTipo = Convert.ToInt32(dr["CTipoDireccion"]);
                            direccion.NTipo = Convert.ToString(dr["NTipoDireccion"]);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return direccion;
        }
                
        public bool Insert(Entity.Tipo_Direccion t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into TipoDireccion values(@NTipo)", con);

                    cmd.Parameters.AddWithValue("@NTipo", t.NTipo);
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

        public bool Update(Entity.Tipo_Direccion t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("update TipoDireccion set NTipoDireccion=@NTipo where CTipoDireccion = @CTipo", con);

                    cmd.Parameters.AddWithValue("@CTipo", t.CTipo);
                    cmd.Parameters.AddWithValue("@NTipo", t.NTipo);
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
