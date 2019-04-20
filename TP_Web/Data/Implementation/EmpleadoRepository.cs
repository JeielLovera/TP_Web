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
            throw new NotImplementedException();
        }

        public List<Empleado> FindAll()
        {
            var empleados = new List<Empleado>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from Empleado", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var empleado = new Empleado();
                            empleado.CEmpleado = Convert.ToInt32(dr["CEmpleado"]);
                            empleado.NEmpleado = dr["NEmpleado"].ToString();
                            empleado.CDniEmpleado = Convert.ToInt32(dr["CDniEmpleado"]);
                            empleado.TDireccionEmpleado = dr["TDireccionEmpleado"].ToString();
                            empleado.NumTelefonoEmpleado= Convert.ToInt32(dr["NumTelefonoEmpleado"]);
                            empleado.FActivo = Convert.ToBoolean(dr["FActivo"]);

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
                    var cmd = new SqlCommand("select * from  Empleado where CEmpleado='" + id + "'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            var emp = new Empleado();
                            emp.CEmpleado = Convert.ToInt32(dr["CEmpleado"]);
                            emp.NEmpleado = dr["NEmpleado"].ToString();
                            emp.CDniEmpleado = Convert.ToInt32(dr["CDniEmpleado"]);
                            emp.TDireccionEmpleado = dr["TDireccionEmpleado"].ToString();
                            emp.NumTelefonoEmpleado = Convert.ToInt32(dr["NumTelefonoEmpleado"]);
                            emp.FActivo = Convert.ToBoolean(dr["FActivo"]);
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
                    var cmd = new SqlCommand("insert into Empleado values(@NEmpleado,@CDniEmpleado,@TDireccionEmpleado,@NumTelefonoEmpleado, @FActivo )", con);

                    cmd.Parameters.AddWithValue("@NEmpleado", t.NEmpleado);
                    cmd.Parameters.AddWithValue("@CDniEmpleado", t.CDniEmpleado);
                    cmd.Parameters.AddWithValue("@TDireccionEmpleado", t.TDireccionEmpleado);
                    cmd.Parameters.AddWithValue("@NumTelefonoEmpleado", t.NumTelefonoEmpleado);
                    cmd.Parameters.AddWithValue("@FActivo", t.FActivo);

                    cmd.ExecuteNonQuery();
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
                    var cmd = new SqlCommand("update Empleado set @NEmpleado,@CDniEmpleado,@TDireccionEmpleado,@NumTelefonoEmpleado, @FActivo where CEmpleado=@CEmpleado", con);

                    cmd.Parameters.AddWithValue("@NEmpleado", t.NEmpleado);
                    cmd.Parameters.AddWithValue("@CDniEmpleado", t.CDniEmpleado);
                    cmd.Parameters.AddWithValue("@TDireccionEmpleado", t.TDireccionEmpleado);
                    cmd.Parameters.AddWithValue("@NumTelefonoEmpleado", t.NumTelefonoEmpleado);
                    cmd.Parameters.AddWithValue("@FActivo", t.FActivo);

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
