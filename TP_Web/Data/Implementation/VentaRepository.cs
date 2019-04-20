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
    public class VentaRepository : IVentaRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Venta> FindAll()
        {
            var ventas = new List<Venta>();
            try
            {
                using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select v.CVenta, v.CLocal, v.CMesa, v.MCostoVenta, v.DFechaVenta, v.QDescuento, v.IGV, ep.CEmpleado NMozo from Venta v, Empleado ep where v.CMozo=ep.CEmpleado", con);
                    using(var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var venta = new Venta();
                            var local = new Local();
                            var mesa = new Mesa();
                            var mozo = new Empleado();

                            venta.CVenta = Convert.ToInt32(dr["CVenta"]);
                            local.CLocal = Convert.ToInt32(dr["CLocal"]);
                            mesa.CLocal = local;
                            venta.CLocal = mesa.CLocal;
                            mesa.CMesa = Convert.ToInt32(dr["CMesa"]);
                            venta.CMesa = mesa;
                            venta.MCostoVenta = Convert.ToDouble(dr["MCostoVenta"]);
                            venta.DFechaVenta = Convert.ToDateTime(dr["DFechaVenta"]);
                            venta.QDescuento = Convert.ToDouble(dr["QDescuento"]);
                            venta.IGV = Convert.ToDouble(dr["IGV"]);
                            mozo.NEmpleado = dr["NMozo"].ToString();
                            venta.CMozo = mozo;
                            ventas.Add(venta);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ventas;
        }

        public Venta FindById(int? id)
        {
            Venta venta = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select v.CVenta, v.CLocal, v.CMesa, v.MCostoVenta, v.DFechaVenta, v.QDescuento, v.IGV, ep.CEmpleado NMozo from Venta v, Empleado ep where v.CMozo=ep.CEmpleado and v.CVenta='"+id+"'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            venta = new Venta();
                            var local = new Local();
                            var mesa = new Mesa();
                            var mozo = new Empleado();

                            venta.CVenta = Convert.ToInt32(dr["CVenta"]);
                            local.CLocal = Convert.ToInt32(dr["CLocal"]);
                            mesa.CLocal = local;
                            venta.CLocal = mesa.CLocal;
                            mesa.CMesa = Convert.ToInt32(dr["CMesa"]);
                            venta.CMesa = mesa;
                            venta.MCostoVenta = Convert.ToDouble(dr["MCostoVenta"]);
                            venta.DFechaVenta = Convert.ToDateTime(dr["DFechaVenta"]);
                            venta.QDescuento = Convert.ToDouble(dr["QDescuento"]);
                            venta.IGV = Convert.ToDouble(dr["IGV"]);
                            mozo.NEmpleado = dr["NMozo"].ToString();
                            venta.CMozo = mozo;
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return venta;
        }

        public bool Insert(Venta t)
        {
            bool rpta = false;
            try
            {
                using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Venta values(@clocal, @cmesa, @costo, @fecha, @descuento, @igv, @cmozo)", con);
                    cmd.Parameters.AddWithValue("@clocal", t.CMesa.CLocal.CLocal);
                    cmd.Parameters.AddWithValue("@cmesa", t.CMesa.CMesa);
                    cmd.Parameters.AddWithValue("@costo", t.MCostoVenta);
                    cmd.Parameters.AddWithValue("@fecha", t.DFechaVenta);
                    cmd.Parameters.AddWithValue("@descuento", t.QDescuento);
                    cmd.Parameters.AddWithValue("@igv", t.IGV);
                    cmd.Parameters.AddWithValue("@cmozo", t.CMozo.CEmpleado);
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

        public bool Update(Venta t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("update Venta set CMesa=@cmesa, MCostoVenta=@costo, DFechaVenta=@fecha, QDescuento=@descuento, IGV=@igv, CMozo=@cmozo where CVenta=@idventa", con);
                    cmd.Parameters.AddWithValue("@idventa", t.CVenta);
                    cmd.Parameters.AddWithValue("@cmesa", t.CMesa.CMesa);
                    cmd.Parameters.AddWithValue("@costo", t.MCostoVenta);
                    cmd.Parameters.AddWithValue("@fecha", t.DFechaVenta);
                    cmd.Parameters.AddWithValue("@descuento", t.QDescuento);
                    cmd.Parameters.AddWithValue("@igv", t.IGV);
                    cmd.Parameters.AddWithValue("@cmozo", t.CMozo.CEmpleado);
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
