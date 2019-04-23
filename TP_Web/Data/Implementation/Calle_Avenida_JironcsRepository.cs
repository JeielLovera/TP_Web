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
    public class Calle_Avenida_JironcsRepository : ICalle_Avenida_JironRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Calle_Avenida_Jiron> FindAll()
        {
            var details = new List<Calle_Avenida_Jiron>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from Calle_Avenida_Jiron", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var detalle = new Calle_Avenida_Jiron();
                            var distrito = new Distrito();
                            var tipo = new Tipo_Direccion();

                            detalle.CCalle_Av_Jiron = Convert.ToInt32(dr["CCalle_Av_Jiron"]);
                            detalle.NCalle_Avenida_Jiron = Convert.ToString(dr["NCalle_Avenida_Jiron"]);
                            detalle.CDistrito = distrito;
                            detalle.CTipo = tipo;

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

        public Calle_Avenida_Jiron FindById(int? id)
        {
            Calle_Avenida_Jiron calle = null;

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
                            var detalle = new Calle_Avenida_Jiron();
                            var distrito = new Distrito();
                            var tipo = new Tipo_Direccion();

                            detalle.CCalle_Av_Jiron = Convert.ToInt32(dr["CCalle_Av_Jiron"]);
                            detalle.NCalle_Avenida_Jiron = Convert.ToString(dr["NCalle_Avenida_Jiron"]);
                            detalle.CDistrito = distrito;
                            detalle.CTipo = tipo;

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

        public Calle_Avenida_Jiron FindById(int? id, int? id2)
        {
            throw new NotImplementedException();
        }

        public Calle_Avenida_Jiron FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Calle_Avenida_Jiron t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Calle_Avenida_Jiron values(@CDniCliente,@CRuc,@NCliente,@NumTelefonoCliente)", con);

                    cmd.Parameters.AddWithValue("@CCalle_Av_Jiron", t.CCalle_Av_Jiron);
                    cmd.Parameters.AddWithValue("@NCalle_Avenida_Jiron", t.NCalle_Avenida_Jiron);
                    cmd.Parameters.AddWithValue("@CDistrito", t.CDistrito);
                    cmd.Parameters.AddWithValue("@CTipo", t.CTipo);

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

        public bool Update(Calle_Avenida_Jiron t)
        {
            throw new NotImplementedException();
        }
    }
}
