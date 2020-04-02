using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using PracticeAPI.Models;

namespace PracticeAPI
{
    public class ProductDB
    {
        private static string _constr = Convert.ToString(ConfigurationManager.ConnectionStrings["Constr"]);

        public int Save(Product obj)
        {
            try
            {
                int x = 0;
                using (SqlConnection con = new SqlConnection(_constr))
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = SaveSql();
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Name", obj.Name);
                        cmd.Parameters.AddWithValue("@DOM", obj.DOM);
                        cmd.Parameters.AddWithValue("@DOE", obj.DOE);
                        cmd.Parameters.AddWithValue("@Active", obj.Active);
                        con.Open();
                        x = cmd.ExecuteNonQuery();
                        return x;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public int Update(Product obj)
        {
            try
            {
                int x = 0;
                using (SqlConnection con = new SqlConnection(_constr))
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = UpdateSql();
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Name", obj.Name);
                        cmd.Parameters.AddWithValue("@DOM", obj.DOM);
                        cmd.Parameters.AddWithValue("@DOE", obj.DOE);
                        cmd.Parameters.AddWithValue("@Active", obj.Active);
                        con.Open();
                        x = cmd.ExecuteNonQuery();
                        return x;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Product> Get()
        {
            try
            {
                List<Product> _lst =new List<Product> ();

                using (SqlConnection con = new SqlConnection(_constr))
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT  ID, Name , DOM, DOE,Active fROM Product";
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Product obj = new Product();
                                obj.Id = reader["id"] == DBNull.Value ? default(Int32) : Convert.ToInt32(reader["Id"]);
                                obj.Name = reader["Name"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Name"]);
                                obj.DOE = reader["DOE"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DOE"]);
                                obj.DOM = reader["DOM"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DOM"]);
                                obj.Active = reader["Active"] == DBNull.Value ? default(bool) : Convert.ToBoolean(reader["Active"]);
                                _lst.Add(obj);
                            }
                        }
                        return _lst ;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Delete(int Id)
        {
            try
            {
                 int x = 0;
                using (SqlConnection con = new SqlConnection(_constr))
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "DELETE FROM PRODUCT WHERE id =@ID";
                        cmd.Parameters.AddWithValue("@ID", Id);
                        con.Open();
                        x = cmd.ExecuteNonQuery();
                        return x;
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        private string SaveSql()
        {
            string str = @"
INSERT INTO Product (Id , Name, DOM, DOE, Active) 
Values(@Id , @Name, @DOM, @DOE, @Active)
";
            return str;
        }

        private string UpdateSql()
        {
            string str = @"
UPDATE Product SET  Name =@Name , DOM =@DOM , DOE=@DOE, ACTIVE =@Active WHERE Id =@Id ";
            return str;
        }
    }
}