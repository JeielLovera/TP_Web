﻿using System;
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
    public class Producto_IngredienteRepository : IProducto_IngredienteRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Producto_Ingrediente> FindAll()
        {
            var arr_prodctingrednt = new List<Producto_Ingrediente>();
            try
            {
                using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select ip.CProducto, p.NProducto, ip.CIngrediente, i.NIngrediente, ip.QUsadaIngrediente, ip.NUnidadMedidaUsada from Producto_Ingrediente pi, Producto p, Ingrediente i where pi.CProducto=p.CProducto and pi.CIngrediente=i.CIngrediente", con);
                    using(var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var productoingrediente = new Producto_Ingrediente();
                            var producto = new Producto();
                            var ingrediente = new Ingrediente();

                            producto.CProducto = Convert.ToInt32(dr["CProducto"]);
                            producto.NProducto = dr["NProducto"].ToString();
                            productoingrediente.CProducto = producto;
                            ingrediente.CIngrediente = Convert.ToInt32(dr["CIngrediente"]);
                            ingrediente.NIngrediente = dr["NIngrediente"].ToString();
                            productoingrediente.CIngrediente = ingrediente;
                            productoingrediente.QUsadaIngrediente = Convert.ToInt32(dr["QUsadaIngrediente"]);
                            productoingrediente.NUnidadMedidaUsada = dr["NUnidadMedidaUsada"].ToString();
                            arr_prodctingrednt.Add(productoingrediente);
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception)
            {
                throw;
            }
            return arr_prodctingrednt;
        }

        public Producto_Ingrediente FindById(int? id)
        {
            throw new NotImplementedException();            
        }

        public Producto_Ingrediente FindById(int? id, int? id2)
        {
            Producto_Ingrediente productoingrediente = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select ip.CProducto, p.NProducto, ip.CIngrediente, i.NIngrediente, ip.QUsadaIngrediente, ip.NUnidadMedidaUsada from Producto_Ingrediente pi, Producto p, Ingrediente i where pi.CProducto=p.CProducto and pi.CIngrediente=i.CIngrediente and pi.CProducto='" + id + "' pi.CIngrediente='" + id2 + "'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            productoingrediente = new Producto_Ingrediente();
                            var producto = new Producto();
                            var ingrediente = new Ingrediente();

                            producto.CProducto = Convert.ToInt32(dr["CProducto"]);
                            producto.NProducto = dr["NProducto"].ToString();
                            productoingrediente.CProducto = producto;
                            ingrediente.CIngrediente = Convert.ToInt32(dr["CIngrediente"]);
                            ingrediente.NIngrediente = dr["NIngrediente"].ToString();
                            productoingrediente.CIngrediente = ingrediente;
                            productoingrediente.QUsadaIngrediente = Convert.ToInt32(dr["QUsadaIngrediente"]);
                            productoingrediente.NUnidadMedidaUsada = dr["NUnidadMedidaUsada"].ToString();

                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return productoingrediente;
        }

        public Producto_Ingrediente FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Producto_Ingrediente t)
        {
            bool rpta = false;
            try
            {
                using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Producto_Ingrediente values (@idprodct, @idingrdnt, @qusada, @nusada)", con);
                    cmd.Parameters.AddWithValue("@idprodct", t.CProducto.CProducto);
                    cmd.Parameters.AddWithValue("@idingrdnt", t.CIngrediente.CIngrediente);
                    cmd.Parameters.AddWithValue("@qusada", t.QUsadaIngrediente);
                    cmd.Parameters.AddWithValue("@nusada", t.NUnidadMedidaUsada);
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

        public bool Update(Producto_Ingrediente t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("update Producto_Ingrediente set CIngrediente=@idingrdnt, QUsadaIngrediente=@qusada, NUnidadMedidaUsada=@nusada where CProducto=@idprodct and CIngrediente=@idingrdnt", con);
                    cmd.Parameters.AddWithValue("@idprodct", t.CProducto.CProducto);
                    cmd.Parameters.AddWithValue("@idingrdnt", t.CIngrediente.CIngrediente);
                    cmd.Parameters.AddWithValue("@idingrdnt", t.CIngrediente.CIngrediente);
                    cmd.Parameters.AddWithValue("@qusada", t.QUsadaIngrediente);
                    cmd.Parameters.AddWithValue("@nusada", t.NUnidadMedidaUsada);
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
