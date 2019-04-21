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
    public class Historial_JefeRepository : IHistorial_JefeRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Historial_Jefe> FindAll()
        {
            var historiales = new List<Historial_Jefe>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select h.CEmpleado, ep1.NEmpleado, h.DFechaHJefe FechaHistorial, ep2.NEmpleado NJefe from Historial_Jefe h, Empleado ep1, Empleado ep2 where h.CEmpleado=ep1.CEmpleado and h.CJefe=ep2.CEmpleado", con);
                    using(var dr=cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var historial = new Historial_Jefe();
                            var empleado = new Empleado();
                            var jefe = new Empleado();

                            empleado.CEmpleado = Convert.ToInt32(dr["CEmpleado"]);
                            empleado.NEmpleado = dr["NEmpleado"].ToString();
                            historial.CEmpleado = empleado;
                            historial.DFechaHJefe = Convert.ToDateTime(dr["FechaHistorial"]);
                            jefe.NEmpleado = dr["NJefe"].ToString();
                            historial.CJefe = jefe;
                            historiales.Add(historial);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

            }
            return historiales;
        }

        public Historial_Jefe FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public Historial_Jefe FindById(int? id, int? id2)
        {            
            Historial_Jefe historial = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select h.CEmpleado, ep1.NEmpleado, h.DFechaHJefe FechaHistorial, ep2.NEmpleado NJefe from Historial_Jefe h, Empleado ep1, Empleado ep2 where h.CEmpleado=ep1.CEmpleado and h.CJefe=ep2.CEmpleado and h.CEmpleado='" + id + "' and h.DFechaHJefe='"+id2+"'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            historial = new Historial_Jefe();
                            var empleado = new Empleado();
                            var jefe = new Empleado();
                            empleado.CEmpleado = Convert.ToInt32(dr["CEmpleado"]);
                            empleado.NEmpleado = dr["NEmpleado"].ToString();
                            historial.CEmpleado = empleado;
                            historial.DFechaHJefe = Convert.ToDateTime(dr["FechaHistorial"]);
                            jefe.NEmpleado = dr["NJefe"].ToString();
                            historial.CJefe = jefe;
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return historial;
        }

        public Historial_Jefe FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Historial_Jefe t)
        {
            bool rpta = false;
            try
            {
                using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Historial_Jefe values(@idempleado,@fecha,@idjefe)", con);
                    cmd.Parameters.AddWithValue("@idempleado", t.CEmpleado.CEmpleado);
                    cmd.Parameters.AddWithValue("@fecha", t.DFechaHJefe);
                    cmd.Parameters.AddWithValue("@idjefe", t.CJefe.CEmpleado);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    rpta = true;
                }
            }
            catch(Exception)
            {

            }
            return rpta;
        }

        public bool Update(Historial_Jefe t)
        {
            bool rpta = false;
            try
            {
                using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("update Historial_Jefe set CJefe=@idjefe where CEmpleado=@id and DFechaHJefe=@fecha", con);
                    cmd.Parameters.AddWithValue("@id", t.CEmpleado.CEmpleado);
                    cmd.Parameters.AddWithValue("@fecha", t.DFechaHJefe);
                    cmd.Parameters.AddWithValue("@idjefe", t.CJefe.CEmpleado);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    rpta = true;
                }
            }
            catch (Exception)
            {

            }
            return rpta;
        }
    }
}
