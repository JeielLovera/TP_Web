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
    public class DireccionRepository : IDireccionRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Direccion> FindAll()
        {
            var details = new List<Direccion>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select dir.CDireccion, dir.NDireccion, tp.NTipoDireccion, dt.NDistrito from Direccion dir, Distrito dt, TipoDireccion tp where dir.CDistrito=dt.CDistrito and dir.CTipoDireccion=tp.CTipoDireccion ", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var detalle = new Direccion();
                            var distrito = new Distrito();
                            var tipo = new Tipo_Direccion();

                            detalle.CDireccion = Convert.ToInt32(dr["CDireccion"]);
                            detalle.NDireccion = dr["NDireccion"].ToString();
                            tipo.NTipo = dr["NTipoDireccion"].ToString();
                            detalle.CTipoDireccion = tipo;
                            distrito.NDistrito = dr["NDistrito"].ToString();
                            detalle.CDistrito = distrito;

                            details.Add(detalle);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return details;
        }

        public Direccion FindById(int? id)
        {
            Direccion detalle = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select dir.CDireccion, dir.NDireccion, tp.NTipoDireccion, dt.NDistrito from Direccion dir, Distrito dt, TipoDireccion tp where dir.CDistrito=dt.CDistrito and dir.CTipoDireccion=tp.CTipoDireccion and dir.CDireccion='"+id+"'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            detalle = new Direccion();
                            var distrito = new Distrito();
                            var tipo = new Tipo_Direccion();

                            detalle.CDireccion = Convert.ToInt32(dr["CDireccion"]);
                            detalle.NDireccion = dr["NDireccion"].ToString();
                            tipo.NTipo = dr["NTipoDireccion"].ToString();
                            detalle.CTipoDireccion = tipo;
                            distrito.NDistrito = dr["NDistrito"].ToString();
                            detalle.CDistrito = distrito;
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return detalle;
        }

        public bool Insert(Direccion t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Direccion values(@ndireccion,@ctipo,@cdistrito)", con);

                    
                    cmd.Parameters.AddWithValue("@ndireccion", t.NDireccion);
                    cmd.Parameters.AddWithValue("@ctipo", t.CTipoDireccion.CTipo);
                    cmd.Parameters.AddWithValue("@cdistrito", t.CDistrito.CDistrito);                    

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

        public bool Update(Direccion t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("update Direccion set NDireccion=@ndireccion , CDistrito=@cdistrito, CTipoDireccion=@ctipo where CDireccion=@cdireccion", con);

                    cmd.Parameters.AddWithValue("@cdireccion", t.CDireccion);
                    cmd.Parameters.AddWithValue("@ndireccion", t.NDireccion);
                    cmd.Parameters.AddWithValue("@cdistrito", t.CDistrito.CDistrito);
                    cmd.Parameters.AddWithValue("@ctipo", t.CTipoDireccion.CTipo);

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
