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
    public class OrdenRepository : IOrdenRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Orden> FindAll()
        {
            var ordenes = new List<Orden>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from Orden", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var orden = new Orden();
                            var venta = new Venta();
                            venta.CVenta = Convert.ToInt32(dr["CVenta"]);
                            orden.CVenta = venta;
                            orden.COrden = Convert.ToInt32(dr["COrden"]);
                            orden.FOrdenAtendida = Convert.ToBoolean(dr["FOrdenAtendida"]);
                            orden.DHoraEntrega = Convert.ToDateTime(dr["DHoraEntrega"]);

                            ordenes.Add(orden);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ordenes;
        }

        public Orden FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public Orden FindById(int? id, int? id2)
        {
            Orden orden = null;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from Orden o where o.CVenta='" + id + "' and o.COrden='"+id2+"'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            orden = new Orden();
                            var venta = new Venta();
                            venta.CVenta = Convert.ToInt32(dr["CVenta"]);
                            orden.CVenta = venta;
                            orden.COrden = Convert.ToInt32(dr["COrden"]);
                            orden.FOrdenAtendida = Convert.ToBoolean(dr["FOrdenAtendida"]);
                            orden.DHoraEntrega = Convert.ToDateTime(dr["DHoraEntrega"]);

                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return orden;
        }

        public Orden FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Orden t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Orden values(@CVenta,@COrden, @FOrdenAtendida, @DHoraEntrega)", con);
                    cmd.Parameters.AddWithValue("@CVenta", t.CVenta.CVenta);
                    cmd.Parameters.AddWithValue("@COrden", t.COrden);
                    cmd.Parameters.AddWithValue("@FOrdenAtendida", t.FOrdenAtendida);
                    cmd.Parameters.AddWithValue("@DHoraEntrega", t.DHoraEntrega);

                    cmd.ExecuteNonQuery();
                    rpta = true;
                    con.Close();
                }
            }
            catch (Exception)
            { throw; }

            return rpta;
        }

        public bool Update(Orden t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("update Orden set FOrdenAtendida=@FOrdenAtendida, DHoraEntrega=@DHoraEntrega where CVenta = @CVenta and COrden = @COrden",con);
                    cmd.Parameters.AddWithValue("@CVenta", t.CVenta.CVenta);
                    cmd.Parameters.AddWithValue("@COrden", t.COrden);
                    cmd.Parameters.AddWithValue("@FOrdenAtendida", t.FOrdenAtendida);
                    cmd.Parameters.AddWithValue("@DHoraEntrega", t.DHoraEntrega);

                    cmd.ExecuteNonQuery();
                    rpta = true;
                    con.Close();
                }
            }
            catch (Exception)
            { throw; }

            return rpta;
        }
    }
}
