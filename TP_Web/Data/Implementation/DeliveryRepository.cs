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
    public class DeliveryRepository : IDeliveryRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Entity.Delivery> FindAll()
        {
            var deliverys = new List<Delivery>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from Delivery", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var delivery = new Delivery();
                            var venta = new Venta();
                            var empleadomoto = new Empleado();
                            var calle_ = new Calle_Avenida_Jiron();

                            delivery.CDelivery = venta;
                            delivery.CEmpleadoMotorizado = empleadomoto;
                            delivery.CCalle_Av_Jiron = calle_;

                            delivery.DHoraEntrega = Convert.ToDateTime(dr["DHoraEntrega"]);
                            delivery.NumDireccionDelivery = Convert.ToInt32(dr["NumDireccionDelivery"]);
                            delivery.TReferencia = Convert.ToString(dr["TReferencia"]);

                            deliverys.Add(delivery);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return deliverys;
        }

        public Entity.Delivery FindById(int? id)
        {
            Delivery delivery = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from Delivery where CDelivery = '" + id + "'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            
                            var venta = new Venta();
                            var empleadomoto = new Empleado();
                            var calle_ = new Calle_Avenida_Jiron();

                            delivery.CDelivery = venta;
                            delivery.CEmpleadoMotorizado = empleadomoto;
                            delivery.CCalle_Av_Jiron = calle_;

                            delivery.DHoraEntrega = Convert.ToDateTime(dr["DHoraEntrega"]);
                            delivery.NumDireccionDelivery = Convert.ToInt32(dr["NumDireccionDelivery"]);
                            delivery.TReferencia = Convert.ToString(dr["TReferencia"]);

                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return delivery;
        }

        public Entity.Delivery FindById(int? id, int? id2)
        {
            throw new NotImplementedException();
        }

        public Entity.Delivery FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Entity.Delivery t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Delivery values(@CDelivery,@CEmpleadoMotorizado,@CCalle_Av_Jiron,@NumDireccionDelivery,@DHoraEntrega,@TReferencia)", con);

                    cmd.Parameters.AddWithValue("@CDelivery", t.CDelivery);
                    cmd.Parameters.AddWithValue("@CEmpleadoMotorizado", t.CEmpleadoMotorizado);
                    cmd.Parameters.AddWithValue("@CCalle_Av_Jiron", t.CCalle_Av_Jiron);
                    cmd.Parameters.AddWithValue("@NumDireccionDelivery", t.NumDireccionDelivery);
                    cmd.Parameters.AddWithValue("@DHoraEntrega", t.DHoraEntrega);
                    cmd.Parameters.AddWithValue("@TReferencia", t.TReferencia);

                    cmd.ExecuteNonQuery();

                    rpta = true;
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rpta;
        }

        public bool Update(Entity.Delivery t)
        {
            throw new NotImplementedException();
        }
    }
}
