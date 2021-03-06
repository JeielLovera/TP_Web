﻿using System;
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
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("delete from Cliente where CCliente='" + id + "'", con);
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

        public List<Entity.Cliente> FindAll()
        {
            var clientes = new List<Cliente>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select cl.CCliente, cl.NCliente, cl.NumTelefono, dir.NDireccion from Cliente cl, Direccion dir where cl.CDireccion=dir.CDireccion", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var cliente = new Cliente();
                            var direccion = new Direccion();

                            cliente.CCliente = Convert.ToInt32(dr["CCliente"]);
                            cliente.NCliente = Convert.ToString(dr["NCliente"]);
                            cliente.NumTelefonoCliente = Convert.ToInt32(dr["NumTelefono"]);
                            direccion.NDireccion = dr["NDireccion"].ToString();
                            cliente.CDireccion = direccion;

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
                    var cmd = new SqlCommand("select cl.CCliente, cl.NCliente, cl.NumTelefono, dir.NDireccion from Cliente cl, Direccion dir where cl.CDireccion=dir.CDireccion and cl.CCliente='"+id+"'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cliente = new Cliente();
                            var direccion = new Direccion();

                            cliente.CCliente = Convert.ToInt32(dr["CCliente"]);
                            cliente.NCliente = Convert.ToString(dr["NCliente"]);
                            cliente.NumTelefonoCliente = Convert.ToInt32(dr["NumTelefono"]);
                            direccion.NDireccion = dr["NDireccion"].ToString();
                            cliente.CDireccion = direccion;
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
        
        public bool Insert(Cliente t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Cliente values(@NCliente,@NumTelefonoCliente, @CDireccion)", con);


                    cmd.Parameters.AddWithValue("@NCliente", t.NCliente);
                    cmd.Parameters.AddWithValue("@NumTelefonoCliente", t.NumTelefonoCliente);
                    cmd.Parameters.AddWithValue("@CDireccion", t.CDireccion.CDireccion);

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

        public bool Update(Cliente t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("update Cliente set NCliente=@ncliente, NumTelefono=@telefono, CDireccion=@direccion where CCliente=@ccliente", con);

                    cmd.Parameters.AddWithValue("@ccliente", t.CCliente);
                    cmd.Parameters.AddWithValue("@ncliente", t.NCliente);
                    cmd.Parameters.AddWithValue("@telefono", t.NumTelefonoCliente);
                    cmd.Parameters.AddWithValue("@direccion", t.CDireccion.CDireccion);

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
    }
}
