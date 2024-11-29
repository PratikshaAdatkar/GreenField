using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using ECommerceEntities;

namespace ECommerceDALLib
{
    public static class DBManager
    {

        public static string conString = @"data source=shc-sql-01.database.windows.net ; database=HangFireCatalog_VG; User Id=tmgreadonly; Password=#p7P>Wzs;";

        public static bool Insert(Product product)
        {
            bool status = false;
            IDbConnection con = new SqlConnection(conString);
            string query = "INSERT INTO products_pratiksha (Id, Name, Description, UnitPrice, Quantity, image)"
                           + "values(" + product.Id + ", '" + product.Name + "')";

            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return status;
        }

        public static bool Update(Product product)
        {
            bool status = false;
            IDbConnection con = new SqlConnection(conString);
            // Use parameterized query to avoid SQL injection
            string query = "UPDATE products_pratiksha SET Name = @Name, Description = @Description, UnitPrice = @UnitPrice, Quantity = @Quantity, image = @image WHERE Id = @Id";
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            // Add parameters to avoid SQL injection
            cmd.Parameters.Add(new SqlParameter("@Name", product.Name));
            cmd.Parameters.Add(new SqlParameter("@Description", product.Description));
            cmd.Parameters.Add(new SqlParameter("@UnitPrice", product.UnitPrice));
            cmd.Parameters.Add(new SqlParameter("@Quantity", product.Quantity));
            cmd.Parameters.Add(new SqlParameter("@image", product.image));
            cmd.Parameters.Add(new SqlParameter("@Id", product.Id));
            try
            {
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                // If at least one row was affected, the update was successful
                if (rowsAffected > 0)
                {
                    status = true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return status;
        }
        public static void Delete(int id)
        {
            IDbConnection con = new SqlConnection(conString);
            string query = "DELETE from products_pratiksha WHERE Id=2";
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public static void GetCount()
        {

            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT COUNT(*) from products_pratiksha";
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            try
            {
                con.Open();
                int count = int.Parse(cmd.ExecuteScalar().ToString());
                Console.WriteLine("Records {0}", count, 56);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                con.Close();
            }
        }


        public static List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT * from products_pratiksha";
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            try
            {
                con.Open();
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr["Name"].ToString();
                    string description = dr["Description"].ToString();
                    int quantity = int.Parse(dr["Quantity"].ToString());

                    Product product = new Product();
                    product.Name = name;
                    product.Description = description;
                    product.Quantity = quantity;
                    products.Add(product);

                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                con.Close();
            }
            return products;

        }

        public static Product GetById(int id)
        {
            List<Product> products = new List<Product>();

            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT * from products_pratiksha WHERE Id=" + id;
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            Product product = new Product();
            try
            {
                con.Open();
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr["Name"].ToString();
                    string description = dr["Description"].ToString();
                    int quantity = int.Parse(dr["Quantity"].ToString());

                    
                    product.Name = name;
                    product.Description = description;
                    product.Quantity = quantity;
                    products.Add(product);


                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                con.Close();
            }
            return product;
        }

    }
}