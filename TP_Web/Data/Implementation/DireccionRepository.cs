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
                    var cmd = new SqlCommand("select * from Direccion", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var detalle = new Direccion();
                            var distrito = new Distrito();
                            var tipo = new Tipo_Direccion();

                            detalle.CDireccion = Convert.ToInt32(dr["CDireccion"]);
                            detalle.NDireccion = Convert.ToString(dr["NDireccion"]);
                            detalle.CDistrito = distrito;
                            detalle.CTipoDireccion = tipo;

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
            Direccion calle = null;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from Calle_Avenida_Jiron where ='" + id +"'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var detalle = new Direccion();
                            var distrito = new Distrito();
                            var tipo = new Tipo_Direccion();

                            detalle.CDireccion = Convert.ToInt32(dr["CDireccion"]);
                            detalle.NDireccion = Convert.ToString(dr["NDireccion"]);
                            detalle.CDistrito = distrito;
                            detalle.CTipoDireccion = tipo;

                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return calle;
        }

        public Direccion FindById(int? id, int? id2)
        {
            throw new NotImplementedException();
        }

        public Direccion FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Direccion t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Direccion values(@NDireccion,@CDistrito,@CTipoDireccion)", con);

                    
                    cmd.Parameters.AddWithValue("@NDireccion", t.NDireccion);
                    cmd.Parameters.AddWithValue("@CDistrito", t.CDistrito);
                    cmd.Parameters.AddWithValue("@CTipoDireccion", t.CTipoDireccion);

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

        public bool Update(Direccion t)
        {
            throw new NotImplementedException();
        }
    }
}
