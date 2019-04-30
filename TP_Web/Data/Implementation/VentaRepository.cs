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
                    var cmd = new SqlCommand("select v.CVenta, v.CLocal, v.MCostoVenta, v.DFechaVenta, v.QDescuento, v.IGV, ep.NEmpleado NMotorizado, cl.NCliente, dir.NDireccion, v.DHoraEntrega , v.TReferencia Referencia from Venta v, Empleado ep, Cliente cl, Direccion dir where v.CMotorizado=ep.CEmpleado and v.CCliente=cl.CCliente and dir.CDireccion=cl.CDireccion", con);
                    using(var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var venta = new Venta();
                            var local = new Local();
                            var motorizado = new Empleado();
                            var cliente = new Cliente();
                            var direccion = new Direccion();

                            venta.CVenta = Convert.ToInt32(dr["CVenta"]);
                            local.CLocal = Convert.ToInt32(dr["CLocal"]);
                            venta.CLocal = local;
                            venta.MCostoVenta = Convert.ToDouble(dr["MCostoVenta"]);
                            venta.DFechaVenta = Convert.ToDateTime(dr["DFechaVenta"]);
                            venta.QDescuento = Convert.ToDouble(dr["QDescuento"]);
                            venta.IGV = Convert.ToDouble(dr["IGV"]);
                            motorizado.NEmpleado = dr["NMotorizado"].ToString();
                            venta.CMotorizado = motorizado;
                            cliente.NCliente = dr["NCliente"].ToString();
                            direccion.NDireccion = dr["NDireccion"].ToString();
                            cliente.CDireccion = direccion;
                            venta.CCliente = cliente;
                            venta.DHoraEntrega = Convert.ToDateTime(dr["DHoraEntrega"]);
                            venta.TReferencia = dr["Referencia"].ToString();
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
                    var cmd = new SqlCommand("select v.CVenta, v.CLocal, v.MCostoVenta, v.DFechaVenta, v.QDescuento, v.IGV, ep.NEmpleado NMotorizado, cl.NCliente, dir.NDireccion, v.DHoraEntrega , v.TReferencia Referencia from Venta v, Empleado ep, Cliente cl, Direccion dir where v.CMotorizado=ep.CEmpleado and v.CCliente=cl.CCliente and dir.CDireccion=cl.CDireccion and v.CVenta='"+id+"'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            venta = new Venta();
                            var local = new Local();
                            var motorizado = new Empleado();
                            var cliente = new Cliente();
                            var direccion = new Direccion();

                            venta.CVenta = Convert.ToInt32(dr["CVenta"]);
                            local.CLocal = Convert.ToInt32(dr["CLocal"]);
                            venta.CLocal = local;
                            venta.MCostoVenta = Convert.ToDouble(dr["MCostoVenta"]);
                            venta.DFechaVenta = Convert.ToDateTime(dr["DFechaVenta"]);
                            venta.QDescuento = Convert.ToDouble(dr["QDescuento"]);
                            venta.IGV = Convert.ToDouble(dr["IGV"]);
                            motorizado.NEmpleado = dr["NMotorizado"].ToString();
                            venta.CMotorizado = motorizado;
                            cliente.NCliente = dr["NCliente"].ToString();
                            direccion.NDireccion = dr["NDireccion"].ToString();
                            cliente.CDireccion = direccion;
                            venta.CCliente = cliente;
                            venta.DHoraEntrega = Convert.ToDateTime(dr["DHoraEntrega"]);
                            venta.TReferencia = dr["Referencia"].ToString();
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
                    var cmd = new SqlCommand("insert into Venta values(@clocal, @costo, @fecha, @descuento, @igv, @cmotorizado, @ccliente, @hora, @referencia)", con);
                    cmd.Parameters.AddWithValue("@clocal", t.CLocal.CLocal);
                    cmd.Parameters.AddWithValue("@costo", t.MCostoVenta);
                    cmd.Parameters.AddWithValue("@fecha", t.DFechaVenta);
                    cmd.Parameters.AddWithValue("@descuento", t.QDescuento);
                    cmd.Parameters.AddWithValue("@igv", t.IGV);
                    cmd.Parameters.AddWithValue("@cmotorizado", t.CMotorizado.CEmpleado);
                    cmd.Parameters.AddWithValue("@ccliente", t.CCliente.CCliente);
                    cmd.Parameters.AddWithValue("@hora", t.DHoraEntrega);
                    cmd.Parameters.AddWithValue("@referencia", t.TReferencia);
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
                    var cmd = new SqlCommand("update Venta set CLocal=@clocal, MCostoVenta=@costo, DFechaVenta=@fecha, QDescuento=@descuento, IGV=@igv, CMotorizado=@cmotorizado, CCliente=@ccliente, DHoraEntrega=@hora, TReferencia=@referencia where CVenta=@idventa", con);
                    cmd.Parameters.AddWithValue("@idventa", t.CVenta);
                    cmd.Parameters.AddWithValue("@clocal", t.CLocal.CLocal);
                    cmd.Parameters.AddWithValue("@costo", t.MCostoVenta);
                    cmd.Parameters.AddWithValue("@fecha", t.DFechaVenta);
                    cmd.Parameters.AddWithValue("@descuento", t.QDescuento);
                    cmd.Parameters.AddWithValue("@igv", t.IGV);
                    cmd.Parameters.AddWithValue("@cmotorizado", t.CMotorizado.CEmpleado);
                    cmd.Parameters.AddWithValue("@ccliente", t.CCliente.CCliente);
                    cmd.Parameters.AddWithValue("@hora", t.DHoraEntrega);
                    cmd.Parameters.AddWithValue("@referencia", t.TReferencia);
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
