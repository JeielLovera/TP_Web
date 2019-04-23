using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using Entity;

namespace Data.Implementation
{
    public class ClienteRepository : IClienteRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Entity.Cliente> FindAll()
        {
            var clientes = new List<Cliente>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from Cliente", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var cliente = new Cliente();

                            cliente.CCLiente = Convert.ToString(dr["CCliente"]);
                            cliente.CDniCliente = Convert.ToInt32(dr["CDniCliente"]);
                            cliente.CRuc = Convert.ToInt32(dr["CRuc"]);
                            cliente.NCliente = Convert.ToString(dr["NCliente"]);
                            cliente.NumTelefonoCliente = Convert.ToInt32(dr["NumTelefonoCliente"]);
                            clientes.Add(cliente);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return clientes;
        }

        public Entity.Cliente FindById(int? id)
        {
            Cliente cliente = null;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from Cliente where CCliente='" + id + "'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cliente.CCLiente = Convert.ToString(dr["CCliente"]);
                            cliente.CDniCliente = Convert.ToInt32(dr["CDniCliente"]);
                            cliente.CRuc = Convert.ToInt32(dr["CRuc"]);
                            cliente.NCliente = Convert.ToString(dr["NCliente"]);
                            cliente.NumTelefonoCliente = Convert.ToInt32(dr["NumTelefonoCliente"]);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return cliente;
        }

        public Entity.Cliente FindById(int? id, int? id2)
        {
            throw new NotImplementedException();
        }

        public Entity.Cliente FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Entity.Cliente t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Cliente values(@CDniCliente,@CRuc,@NCliente,@NumTelefonoCliente)", con);

                    cmd.Parameters.AddWithValue("@CDniCliente", t.CDniCliente);
                    cmd.Parameters.AddWithValue("@CRuc", t.CRuc);
                    cmd.Parameters.AddWithValue("@NCliente", t.NCliente);
                    cmd.Parameters.AddWithValue("@NumTelefonoCliente", t.NumTelefonoCliente);

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

        public bool Update(Entity.Cliente t)
        {
            throw new NotImplementedException();
        }
    }
}
