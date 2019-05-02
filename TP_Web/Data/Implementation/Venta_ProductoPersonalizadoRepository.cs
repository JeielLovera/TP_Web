using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data.Implementation
{
    public class Venta_ProductoPersonalizadoRepository : IVenta_ProductoPersonalizadoRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("delete from Venta_ProductoPersonalizado where CVenta_Pro_Per='" + id + "'", con);
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

        public List<Venta_ProductoPersonalizado> FindAll()
        {
            var ventas = new List<Venta_ProductoPersonalizado>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select vpp.CVenta_Pro_Per, vpp.CVenta, ig.NIngrediente, vpp.QUsadaIngrediente, vpp.PrecioXGramo from Venta_ProductoPersonalizado vpp, Ingrediente ig where vpp.CIngrediente=ig.CIngrediente", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ventapp = new Venta_ProductoPersonalizado();
                            var venta = new Venta();
                            var ingrediente = new Ingrediente();

                            ventapp.CVenta_Pro_Per = Convert.ToInt32(dr["CVenta_Pro_Per"]);
                            venta.CVenta = Convert.ToInt32(dr["CVenta"]);
                            ventapp.CVenta = venta;
                            ingrediente.NIngrediente = dr["NIngrediente"].ToString();
                            ventapp.CIngrediente = ingrediente;
                            ventapp.QUsadaIngrediente = Convert.ToInt32(dr["QUsadaIngrediente"]);
                            ventapp.PrecioXGramo = Convert.ToDouble(dr["PrecioXGramo"]);
                            ventas.Add(ventapp);
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

        public Venta_ProductoPersonalizado FindById(int? id)
        {
            Venta_ProductoPersonalizado ventapp = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select vpp.CVenta_Pro_Per, vpp.CVenta, ig.NIngrediente, vpp.QUsadaIngrediente, vpp.PrecioXGramo from Venta_ProductoPersonalizado vpp, Ingrediente ig where vpp.CIngrediente=ig.CIngrediente and vpp.CVenta_Pro_Per='"+id+"'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ventapp = new Venta_ProductoPersonalizado();
                            var venta = new Venta();
                            var ingrediente = new Ingrediente();

                            ventapp.CVenta_Pro_Per = Convert.ToInt32(dr["CVenta_Pro_Per"]);
                            venta.CVenta = Convert.ToInt32(dr["CVenta"]);
                            ventapp.CVenta = venta;
                            ingrediente.NIngrediente = dr["NIngrediente"].ToString();
                            ventapp.CIngrediente = ingrediente;
                            ventapp.QUsadaIngrediente = Convert.ToInt32(dr["QUsadaIngrediente"]);
                            ventapp.PrecioXGramo = Convert.ToDouble(dr["PrecioXGramo"]);

                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return ventapp;
        }
        
        public bool Insert(Venta_ProductoPersonalizado t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Venta_ProductoPersonalizado values (@CVenta,@CIngrediente,@QUsadaIngrediente,@PrecioXGramo) ", con);
                    cmd.Parameters.AddWithValue("@CVenta",t.CVenta.CVenta);
                    cmd.Parameters.AddWithValue("@CIngrediente", t.CIngrediente.CIngrediente);
                    cmd.Parameters.AddWithValue("@QUsadaIngrediente", t.QUsadaIngrediente);
                    cmd.Parameters.AddWithValue("@PrecioXGramo", t.PrecioXGramo);
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

        public bool Update(Venta_ProductoPersonalizado t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("update Venta_ProductoPersonalizado set CVenta=@CVenta,CIngrediente=@CIngrediente, QUsadaIngrediente = @QUsadaIngrediente, PrecioXGramo=@PrecioXGramo where CVenta_Pro_Per=@id", con);
                    cmd.Parameters.AddWithValue("@id", t.CVenta_Pro_Per);
                    cmd.Parameters.AddWithValue("@CVenta", t.CVenta.CVenta);
                    cmd.Parameters.AddWithValue("@CIngrediente", t.CIngrediente.CIngrediente);
                    cmd.Parameters.AddWithValue("@QUsadaIngrediente", t.QUsadaIngrediente);
                    cmd.Parameters.AddWithValue("@PrecioXGramo", t.PrecioXGramo);
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
