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
    public class Orden_ProductoPerzonalizadoRepository : IOrden_ProductoPerzonalizadoRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Orden_ProductoPerzonalizado> FindAll()
        {
            var ordenes = new List<Orden_ProductoPerzonalizado>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select opp.CVenta, opp.COrden, opp.CIngrediente, FROM  Orden_Producto op, Orden_ProductoPerzonalizado opp where op.COrden = opp.COrden", con);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var orden_p_p = new Orden_ProductoPerzonalizado();
                            var orden = new Orden();
                            var venta = new Venta();
                            var empleado = new Empleado();
                            var ingrediente = new Ingrediente();

                            orden_p_p.COrden = orden;
                            orden_p_p.CVenta = venta;
                            orden_p_p.CEmpleado = empleado;
                            orden_p_p.CIngrediente = ingrediente;
                            orden_p_p.QOrdenProductoPerzonalizado = Convert.ToInt32(dr["QOrdenProductoPerzonalizado"]);
                            orden_p_p.NUnidadMedidaUsada = Convert.ToString(dr["NUnidadMedidaUsada"]);

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

        public Orden_ProductoPerzonalizado FindById(int? id, int id2)
        {
            Orden_ProductoPerzonalizado orden_p_p = null;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from Orden_ProductoPerzonalizado opp where opp.COrden='" + id + "' and o.CVenta='" + id2 + "'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            
                            var orden = new Orden();
                            var venta = new Venta();
                            var empleado = new Empleado();
                            var ingrediente = new Ingrediente();

                            orden_p_p.COrden = orden;
                            orden_p_p.CVenta = venta;
                            orden_p_p.CEmpleado = empleado;
                            orden_p_p.CIngrediente = ingrediente;
                            orden_p_p.QOrdenProductoPerzonalizado = Convert.ToInt32(dr["QOrdenProductoPerzonalizado"]);
                            orden_p_p.NUnidadMedidaUsada = Convert.ToString(dr["NUnidadMedidaUsada"]);

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

        public Orden_ProductoPerzonalizado FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public Orden_ProductoPerzonalizado FindById(int? id, int? id2)
        {
            throw new NotImplementedException();
        }

        public Orden_ProductoPerzonalizado FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Orden_ProductoPerzonalizado t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Producto values (@CVenta, @COrden,@CIngrediente,@CEmpleado,@QOrdenProductoPerzonalizado,@NUnidadMedidaUsada)", con);
                    cmd.Parameters.AddWithValue("@CVenta", t.CVenta);
                    cmd.Parameters.AddWithValue("@COrden", t.COrden);
                    cmd.Parameters.AddWithValue("@CIngrediente", t.CIngrediente);
                    cmd.Parameters.AddWithValue("@CEmpleado", t.CEmpleado);
                    cmd.Parameters.AddWithValue("@QOrdenProductoPerzonalizado", t.QOrdenProductoPerzonalizado);
                    cmd.Parameters.AddWithValue("@NUnidadMedidaUsada", t.NUnidadMedidaUsada);

                    cmd.ExecuteNonQuery();
                    rpta = true;
                    con.Close();
                }
            }
            catch (Exception)
            { throw; }

            return rpta;
        }

        public bool Update(Orden_ProductoPerzonalizado t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();

                    var cmd = new SqlCommand("update ORden_ProductoPerzonalizado set CIngrediente=@CIngrediente,CEmpleado=@CEmpleado, COrden=@COrden, QOrdenProductoPerzonalizado =@QOrdenProductoPerzonalizado, NUnidadMedidaUsada =@ NUnidadMedidaUsada where COrden=@COrden and CVenta = @CVenta" , con);
                    cmd.Parameters.AddWithValue("@CVenta", t.CVenta);
                    cmd.Parameters.AddWithValue("@COrden", t.COrden);
                    cmd.Parameters.AddWithValue("@CIngrediente", t.CIngrediente);
                    cmd.Parameters.AddWithValue("@CEmpleado", t.CEmpleado);
                    cmd.Parameters.AddWithValue("@QOrdenProductoPerzonalizado", t.QOrdenProductoPerzonalizado);
                    cmd.Parameters.AddWithValue("@NUnidadMedidaUsada", t.NUnidadMedidaUsada);
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
