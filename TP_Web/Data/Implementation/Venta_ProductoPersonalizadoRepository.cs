﻿using System;
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
            throw new NotImplementedException();
        }

        public List<Venta_ProductoPersonalizado> FindAll()
        {
            var ventas = new List<Venta_ProductoPersonalizado>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select v.CVenta, vpp.PrecioXGramo, vpp.QUsadaIngrediente, i.CIngrediente from Venta_ProductoPersonalizado vpp, Venta v,Ingrediente i where vpp.CVenta = v.CVenta and vpp.CIngrediente = i.CIngrediente  ", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ventapp = new Venta_ProductoPersonalizado();
                            var venta = new Venta();
                            var ingrediente = new Ingrediente();

                            ventapp.CVenta = venta;
                            ventapp.CIngrediente = ingrediente;
                            ventapp.PrecioXGramo = Convert.ToInt32(dr["PrecioXGramo"]);
                            ventapp.QUsadaIngrediente = Convert.ToInt32(dr["QUsadaIngrediente"]);

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
            throw new NotImplementedException();
        }

        public Venta_ProductoPersonalizado FindById(int? id, int? id2)
        {
            Venta_ProductoPersonalizado ventapp = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select v.CVenta, vpp.PrecioXGramo, vpp.QUsadaIngrediente, i.CIngrediente from Venta_ProductoPersonalizado vpp, Venta v,Ingrediente i where vpp.CVenta = v.CVenta and vpp.CIngrediente = vpp.CIngrediente and v.CVenta ='" + id + "' and vpp.CIngrediente='" +id2 +"'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var venta = new Venta();
                            var ingrediente = new Ingrediente();

                            ventapp.CVenta = venta;
                            ventapp.CIngrediente = ingrediente;
                            ventapp.PrecioXGramo = Convert.ToInt32(dr["PrecioXGramo"]);
                            ventapp.QUsadaIngrediente = Convert.ToInt32(dr["QUsadaIngrediente"]);
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

        public Venta_ProductoPersonalizado FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
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
                    cmd.Parameters.AddWithValue("@CVenta",t.CVenta);
                    cmd.Parameters.AddWithValue("@CIngrediente", t.CIngrediente);
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
            throw new NotImplementedException();
        }
    }
}
