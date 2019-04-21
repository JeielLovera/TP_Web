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
    public class PlanillaRepository : IPlanillaRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Planilla> FindAll()
        {
            var planillas =new List<Planilla>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select e.CEmpleado, e.NEmpleado,p.DFechaHRol Fecha, r.NRol Rol, p.Msueldo from Empleado e, Planilla p, Rol r where e.CEmpleado = p.CEmpleado and p.CRol = r.CRol");
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var planilla = new Planilla();
                            var empleado = new Empleado();
                            var rol = new Rol();

                            empleado.CEmpleado = Convert.ToInt32(dr["CEmpleado"]);
                            empleado.NEmpleado = dr["NEmpleado"].ToString();
                            planilla.CEmpleado = empleado;
                            planilla.DFechaHRol = Convert.ToDateTime(dr["Fecha"]);
                            rol.NRol= (dr["Rol"]).ToString();
                            planilla.CRol = rol;
                            planilla.MSueldo = Convert.ToSingle(dr["Msueldo"]);

                            planillas.Add(planilla);
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception)
            {
                throw;
            }
            return planillas;
        }

        public Planilla FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public Planilla FindById(int? id, int? id2)
        {
            Planilla planilla = null;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select e.CEmpleado, e.NEmpleado,p.DFechaHRol Fecha, r.NRol Rol, p.Msueldo from Empleado e, Planilla p, Rol r where e.CEmpleado = p.CEmpleado and p.CRol = r.CRol and e.CEmpleado='" + id + "' and p.DFechaHRol='" + id2 + "'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            planilla = new Planilla();
                            var empleado = new Empleado();
                            var rol = new Rol();

                            empleado.CEmpleado = Convert.ToInt32(dr["CEmpleado"]);
                            empleado.NEmpleado = dr["NEmpleado"].ToString();
                            planilla.CEmpleado = empleado;
                            planilla.DFechaHRol = Convert.ToDateTime(dr["Fecha"]);
                            rol.NRol = (dr["Rol"]).ToString();
                            planilla.CRol = rol;
                            planilla.MSueldo = Convert.ToSingle(dr["Msueldo"]);
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception)
            { throw; }

            return planilla;
        }

        public Planilla FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Planilla t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Planilla values(@Cempleado,@fecha, @crol,@sueldo)", con);
                    cmd.Parameters.AddWithValue("@Cempleado", t.CEmpleado.CEmpleado);
                    cmd.Parameters.AddWithValue("@fecha", t.DFechaHRol);
                    cmd.Parameters.AddWithValue("@crol", t.CRol.CRol);
                    cmd.Parameters.AddWithValue("@sueldo", t.MSueldo);

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

        public bool Update(Planilla t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("update Planilla set CRol=@crol, Msueldo=@sueldo where CEmpleado=@cEMepleado and DFechaHRol=@fecha", con);
                    cmd.Parameters.AddWithValue("@Cempleado", t.CEmpleado.CEmpleado);
                    cmd.Parameters.AddWithValue("@fecha", t.DFechaHRol);
                    cmd.Parameters.AddWithValue("@crol", t.CRol.CRol);
                    cmd.Parameters.AddWithValue("@sueldo", t.MSueldo);

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
