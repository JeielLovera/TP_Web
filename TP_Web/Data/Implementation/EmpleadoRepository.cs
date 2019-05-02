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
    public class EmpleadoRepository : IEmpleadoRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("delete from Empleado where CEmpleado='" + id + "'", con);
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

        public List<Empleado> FindAll()
        {
            var empleados = new List<Empleado>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select ep.CEmpleado, ep.NEmpleado, ep.CDniEmpleado, ep.TDireccionEmpleado, ep.NumTelefonoEmpleado, ep.FActivo, r.NRol, jf.NEmpleado NJefe from Empleado ep, Rol r, Empleado jf where ep.CRol=r.CRol and ep.CJefe=jf.CEmpleado", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var empleado = new Empleado();
                            var jefe = new Empleado();
                            var rol = new Rol();
                            empleado.CEmpleado = Convert.ToInt32(dr["CEmpleado"]);
                            empleado.NEmpleado = dr["NEmpleado"].ToString();
                            empleado.CDniEmpleado = Convert.ToInt32(dr["CDniEmpleado"]);
                            empleado.TDireccionEmpleado = dr["TDireccionEmpleado"].ToString();
                            empleado.NumTelefonoEmpleado = Convert.ToInt32(dr["NumTelefonoEmpleado"]);
                            empleado.FActivo = Convert.ToBoolean(dr["FActivo"]);
                            rol.NRol = dr["NRol"].ToString();
                            empleado.CRol = rol;
                            jefe.NEmpleado = dr["NJefe"].ToString();
                            empleado.CJefe = jefe;
                            
                            
                            
                            empleados.Add(empleado);
                        }
                    }
                    con.Close();
                }
            }
            catch(Exception)
            { throw; }
            return empleados;
        }

        public Empleado FindById(int? id)
        {
            Empleado empleado = null;
            
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select ep.CEmpleado, ep.NEmpleado, ep.CDniEmpleado, ep.TDireccionEmpleado, ep.NumTelefonoEmpleado, ep.FActivo, r.NRol, jf.NEmpleado NJefe from Empleado ep, Rol r, Empleado jf where ep.CRol=r.CRol and ep.CJefe=jf.CEmpleado and ep.CEmpleado='"+id+"'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            empleado = new Empleado();
                            var jefe = new Empleado();
                            var rol = new Rol();
                            empleado.CEmpleado = Convert.ToInt32(dr["CEmpleado"]);
                            empleado.NEmpleado = dr["NEmpleado"].ToString();
                            empleado.CDniEmpleado = Convert.ToInt32(dr["CDniEmpleado"]);
                            empleado.TDireccionEmpleado = dr["TDireccionEmpleado"].ToString();
                            empleado.NumTelefonoEmpleado = Convert.ToInt32(dr["NumTelefonoEmpleado"]);
                            empleado.FActivo = Convert.ToBoolean(dr["FActivo"]);
                            rol.NRol = dr["NRol"].ToString();
                            empleado.CRol = rol;
                            jefe.NEmpleado = dr["NJefe"].ToString();
                            empleado.CJefe = jefe;

                        }
                    }
                    con.Close();
                }
            }
            catch(Exception)
            {
                throw;
            }

            return empleado;
        }
                     
        public bool Insert(Empleado t)
        {
            bool rpta=false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Empleado values(@NEmpleado,@CDniEmpleado,@TDireccionEmpleado,@NumTelefonoEmpleado, @FActivo,@CRol, @CJefe)", con);

                    cmd.Parameters.AddWithValue("@NEmpleado", t.NEmpleado);
                    cmd.Parameters.AddWithValue("@CDniEmpleado", t.CDniEmpleado);
                    cmd.Parameters.AddWithValue("@TDireccionEmpleado", t.TDireccionEmpleado);
                    cmd.Parameters.AddWithValue("@NumTelefonoEmpleado", t.NumTelefonoEmpleado);
                    cmd.Parameters.AddWithValue("@FActivo", t.FActivo);
                    cmd.Parameters.AddWithValue("@CRol", t.CRol.CRol);
                    cmd.Parameters.AddWithValue("@CJefe", t.CJefe.CEmpleado);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    rpta = true;
                }
            }
            catch(Exception)
            { throw; }

            return rpta;
        }

        public bool Update(Empleado t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("update Empleado set NEmpleado=@NEmpleado,CDniEmpleado=@CDniEmpleado,TDireccionEmpleado=@TDireccionEmpleado,NumTelefonoEmpleado=@NumTelefonoEmpleado, FActivo=@FActivo,CRol=@CRol, CJefe=@CJefe where CEmpleado=@CEmpleado", con);
                    cmd.Parameters.AddWithValue("@CEmpleado", t.CEmpleado);
                    cmd.Parameters.AddWithValue("@NEmpleado", t.NEmpleado);
                    cmd.Parameters.AddWithValue("@CDniEmpleado", t.CDniEmpleado);
                    cmd.Parameters.AddWithValue("@TDireccionEmpleado", t.TDireccionEmpleado);
                    cmd.Parameters.AddWithValue("@NumTelefonoEmpleado", t.NumTelefonoEmpleado);
                    cmd.Parameters.AddWithValue("@FActivo", t.FActivo);
                    cmd.Parameters.AddWithValue("@CRol", t.CRol.CRol);
                    cmd.Parameters.AddWithValue("@CJefe", t.CJefe.CEmpleado);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    rpta = true;
                }
            }
            catch(Exception)
            { throw; }

            return rpta;
        }
    }
}
