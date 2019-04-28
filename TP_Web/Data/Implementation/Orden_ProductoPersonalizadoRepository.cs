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
    public class Orden_ProductoPersonalizadoRepository : IOrden_ProductoPersonalizadoRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Orden_ProductoPersonalizado> FindAll()
        {
            var ordenes = new List<Orden_ProductoPersonalizado>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from Orden_ProductoPerzonalizado", con);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var orden_p_p = new Orden_ProductoPersonalizado();
                            var orden = new Orden();
                            var venta = new Venta();
                            var empleado = new Empleado();
                            var ingrediente = new Ingrediente();

                            orden.COrden = Convert.ToInt32(dr["COrden"]);
                            orden_p_p.COrden = orden;
                            venta.CVenta = Convert.ToInt32(dr["CVenta"]);
                            orden_p_p.CVenta = venta;
                            empleado.CEmpleado = Convert.ToInt32(dr["CEmpleado"]);
                            orden_p_p.CEmpleado = empleado;
                            ingrediente.CIngrediente = Convert.ToInt32(dr["CIngrediente"]);
                            orden_p_p.CIngrediente = ingrediente;
                            orden_p_p.QOrdenProductoPerzonalizado = Convert.ToInt32(dr["QOrdenProductoPerzonalizado"]);
                            

                            ordenes.Add(orden_p_p);
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception)
            { throw; }

            return ordenes;
        }
        public Orden_ProductoPersonalizado FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public Orden_ProductoPersonalizado FindById(int? id, int? id2)
        {
            throw new NotImplementedException();
        }

        public Orden_ProductoPersonalizado FindById(int? id, int? id2, int? id3)
        {
            Orden_ProductoPersonalizado orden_p_p = null;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from Orden_ProductoPerzonalizado opp where opp.COrden='" + id + "' and opp.CVenta='" + id2 + "' and opp.CIngrediente =" + id3 + "'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var orden = new Orden();
                            var venta = new Venta();
                            var empleado = new Empleado();
                            var ingrediente = new Ingrediente();

                            orden.COrden = Convert.ToInt32(dr["COrden"]);
                            orden_p_p.COrden = orden;
                            venta.CVenta = Convert.ToInt32(dr["CVenta"]);
                            orden_p_p.CVenta = venta;
                            empleado.CEmpleado = Convert.ToInt32(dr["CEmpleado"]);
                            orden_p_p.CEmpleado = empleado;
                            ingrediente.CIngrediente = Convert.ToInt32(dr["CIngrediente"]);
                            orden_p_p.CIngrediente = ingrediente;
                            orden_p_p.QOrdenProductoPerzonalizado = Convert.ToInt32(dr["QOrdenProductoPerzonalizado"]);
                           

                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return orden_p_p;
        }

        public bool Insert(Orden_ProductoPersonalizado t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Producto values (@CVenta, @COrden,@CIngrediente,@CEmpleado,@QOrdenProductoPerzonalizado)", con);
                    cmd.Parameters.AddWithValue("@CVenta", t.CVenta.CVenta);
                    cmd.Parameters.AddWithValue("@COrden", t.COrden.COrden);
                    cmd.Parameters.AddWithValue("@CIngrediente", t.CIngrediente.CIngrediente);
                    cmd.Parameters.AddWithValue("@CEmpleado", t.CEmpleado.CEmpleado);
                    cmd.Parameters.AddWithValue("@QOrdenProductoPerzonalizado", t.QOrdenProductoPerzonalizado);

                    cmd.ExecuteNonQuery();
                    rpta = true;
                    con.Close();
                }
            }
            catch (Exception)
            { throw; }

            return rpta;
        }

        public bool Update(Orden_ProductoPersonalizado t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();

                    var cmd = new SqlCommand("update ORden_ProductoPerzonalizado CEmpleado =@CEmpleado, QOrdenProductoPerzonalizado=@QOrdenProductoPerzonalizado  where COrden=@COrden and CVenta = @CVenta and CIngrediente=@CIngrediente", con);
                    cmd.Parameters.AddWithValue("@CVenta", t.CVenta.CVenta);
                    cmd.Parameters.AddWithValue("@COrden", t.COrden.COrden);
                    cmd.Parameters.AddWithValue("@CIngrediente", t.CIngrediente.CIngrediente);
                    cmd.Parameters.AddWithValue("@CEmpleado", t.CEmpleado.CEmpleado);
                    cmd.Parameters.AddWithValue("@QOrdenProductoPerzonalizado", t.QOrdenProductoPerzonalizado);
                   
                    cmd.ExecuteNonQuery();
                    rpta = true;
                }
            }
            catch (Exception)
            { throw; }
            return rpta;
        }
    }
}
