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
                    var cmd = new SqlCommand("select opp.COrden_Pro_Per, opp.COrden, o.CVenta, ig.NIngrediente, ep.NEmpleado, opp.QOrdenProductoPersonalizado from Orden_ProductoPersonalizado opp, Orden o, Ingrediente ig, Empleado ep where opp.COrden=o.COrden and opp.CIngrediente=ig.CIngrediente and opp.CEmpleado=ep.CEmpleado", con);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var orden_p_p = new Orden_ProductoPersonalizado();
                            var orden = new Orden();
                            var venta = new Venta();
                            var empleado = new Empleado();
                            var ingrediente = new Ingrediente();

                            orden_p_p.COrden_Pro_Per = Convert.ToInt32(dr["COrden_Pro_Per"]);
                            orden.COrden = Convert.ToInt32(dr["COrden"]);
                            venta.CVenta = Convert.ToInt32(dr["CVenta"]);
                            orden.CVenta = venta;
                            orden_p_p.COrden = orden;
                            ingrediente.NIngrediente = dr["NIngrediente"].ToString();
                            orden_p_p.CIngrediente = ingrediente;
                            empleado.NEmpleado = dr["NEmpleado"].ToString();
                            orden_p_p.CEmpleado = empleado;
                            orden_p_p.QOrdenProductoPersonalizado = Convert.ToInt32(dr["QOrdenProductoPersonalizado"]);
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
            Orden_ProductoPersonalizado orden_p_p = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select opp.COrden_Pro_Per, opp.COrden, o.CVenta, ig.NIngrediente, ep.NEmpleado, opp.QOrdenProductoPersonalizado from Orden_ProductoPersonalizado opp, Orden o, Ingrediente ig, Empleado ep where opp.COrden=o.COrden and opp.CIngrediente=ig.CIngrediente and opp.CEmpleado=ep.CEmpleado and opp.COrden_Pro_Per='" + id+"'", con);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            orden_p_p = new Orden_ProductoPersonalizado();
                            var orden = new Orden();
                            var venta = new Venta();
                            var empleado = new Empleado();
                            var ingrediente = new Ingrediente();

                            orden_p_p.COrden_Pro_Per = Convert.ToInt32(dr["COrden_Pro_Per"]);
                            orden.COrden = Convert.ToInt32(dr["COrden"]);
                            venta.CVenta = Convert.ToInt32(dr["CVenta"]);
                            orden.CVenta = venta;
                            orden_p_p.COrden = orden;
                            ingrediente.NIngrediente = dr["NIngrediente"].ToString();
                            orden_p_p.CIngrediente = ingrediente;
                            empleado.NEmpleado = dr["NEmpleado"].ToString();
                            orden_p_p.CEmpleado = empleado;
                            orden_p_p.QOrdenProductoPersonalizado = Convert.ToInt32(dr["QOrdenProductoPersonalizado"]);
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception)
            { throw; }
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
                    var cmd = new SqlCommand("insert into Orden_ProductoPersonalizado values (@COrden,@CIngrediente,@CEmpleado,@QOrdenProductoPersonalizado)", con);
                    cmd.Parameters.AddWithValue("@COrden", t.COrden.COrden);
                    cmd.Parameters.AddWithValue("@CIngrediente", t.CIngrediente.CIngrediente);
                    cmd.Parameters.AddWithValue("@CEmpleado", t.CEmpleado.CEmpleado);
                    cmd.Parameters.AddWithValue("@QOrdenProductoPersonalizado", t.QOrdenProductoPersonalizado);

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

                    var cmd = new SqlCommand("update Orden_ProductoPersonalizado set CIngrediente=@CIngrediente, CEmpleado=@CEmpleado, QOrdenProductoPersonalizado=@QOrdenProductoPersonalizado  where COrden_Pro_Per=@id", con);
                    cmd.Parameters.AddWithValue("@id", t.COrden_Pro_Per);
                    cmd.Parameters.AddWithValue("@CIngrediente", t.CIngrediente.CIngrediente);
                    cmd.Parameters.AddWithValue("@CEmpleado", t.CEmpleado.CEmpleado);
                    cmd.Parameters.AddWithValue("@QOrdenProductoPersonalizado", t.QOrdenProductoPersonalizado);
                   
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
