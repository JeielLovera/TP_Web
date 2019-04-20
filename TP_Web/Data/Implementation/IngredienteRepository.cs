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
    public class IngredienteRepository : IIngredienteRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ingrediente> FindAll()
        {
            var ingredientes = new List<Ingrediente>();
            try
            {
                using (var con=new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select ig.CIngrediente, ig.NIngrediente, ig.QUnidadMedidaIngrediente, ig.NUnidadMedidaIngrediente, tp.NTipoIngrediente as TipoIngrediente from Ingrediente ig, TipoIngrediente tp where ig.CTipoIngrediente=tp.CTipoIngrediente", con);
                    using (var dr=cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ingrediente = new Ingrediente();
                            var tipo = new TipoIngrediente();
                            ingrediente.CIngrediente = Convert.ToInt32(dr["CIngrediente"]);
                            ingrediente.NIngrediente = dr["NIngrediente"].ToString();
                            ingrediente.QUnidadMedidaIngrediente= Convert.ToInt32(dr["QUnidadMedidaIngrediente"]);
                            ingrediente.NUnidadMedidaIngrediente = dr["NUnidadMedidaIngrediente"].ToString();
                            tipo.NTipoIngrediente = dr["TipoIngrediente"].ToString();
                            ingrediente.CTipoIngrediente = tipo;
                            ingredientes.Add(ingrediente);                   
                        }

                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ingredientes;
        }

        public Ingrediente FindById(int? id)
        {
            Ingrediente ingrediente = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select ig.CIngrediente, ig.NIngrediente, ig.QUnidadMedidaIngrediente, ig.NUnidadMedidaIngrediente, tp.NTipoIngrediente as TipoIngrediente from Ingrediente ig, TipoIngrediente tp where ig.CTipoIngrediente='"+id+"'", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        ingrediente = new Ingrediente();
                        var tipo = new TipoIngrediente();
                        ingrediente.CIngrediente = Convert.ToInt32(dr["CIngrediente"]);
                        ingrediente.NIngrediente = dr["NIngrediente"].ToString();
                        ingrediente.QUnidadMedidaIngrediente = Convert.ToInt32(dr["QUnidadMedidaIngrediente"]);
                        ingrediente.NUnidadMedidaIngrediente = dr["NUnidadMedidaIngrediente"].ToString();
                        tipo.NTipoIngrediente = dr["TipoIngrediente"].ToString();
                        ingrediente.CTipoIngrediente = tipo;
                        
                    }
                }

            }
            catch(Exception)
            {
                throw;
            }
            return ingrediente;
            
        }

        public bool Insert(Ingrediente t)
        {
            bool rpta = false;
            try
            {
                using (var con=new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Ingrediente values (@nombre, @qunidadmedida, @nunidadmedida,@ctipo)", con);
                    cmd.Parameters.AddWithValue("@nombre", t.NIngrediente);
                    cmd.Parameters.AddWithValue("@qunidadmedida", t.QUnidadMedidaIngrediente);
                    cmd.Parameters.AddWithValue("@nunidadmedida", t.NUnidadMedidaIngrediente);
                    cmd.Parameters.AddWithValue("@ctipo", t.CTipoIngrediente);
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

        public bool Update(Ingrediente t)
        {
            bool rpta = false;
            try
            {
                using (var con=new SqlConnection(ConfigurationManager.ConnectionStrings["BD_Pizza"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("update Ingrediente set NIngrediente=@nombre, QUnidadMedidaIngrediente=@qunidadmedida, NUnidadMedidaIngrediente=@nunidadmedida, CTipoIngrediente=@ctipo where CIngrediente=@id", con);
                    cmd.Parameters.AddWithValue("@id", t.CIngrediente);
                    cmd.Parameters.AddWithValue("@qunidadmedida", t.QUnidadMedidaIngrediente);
                    cmd.Parameters.AddWithValue("@nunidadmedida", t.NUnidadMedidaIngrediente);
                    cmd.Parameters.AddWithValue("@ctipo", t.CTipoIngrediente);
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
