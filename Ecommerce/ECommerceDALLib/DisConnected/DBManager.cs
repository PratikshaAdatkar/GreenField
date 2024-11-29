using System;

using System.Collections.Generic;

using System.Data.SqlClient;

using System.Data;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.Net.Http.Headers;

using ECommerceEntities;

namespace ECommerceDALLib.DisConnectedDataAccess

{

    public static class DBManager

    {

        public static string conString = @"data source=shc-sql-01.database.windows.net ; database=HangFireCatalog_VG; User Id=tmgreadonly; Password=#p7P>Wzs;";

        public static bool Insert(Product product)

        {

            IDbConnection conn = new SqlConnection(conString);

            string query = "SELECT * FROM products_pratiksha";

            IDbCommand cmd = new SqlCommand(query, conn as SqlConnection);

            IDataAdapter adapter = new SqlDataAdapter(cmd as SqlCommand);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter as SqlDataAdapter);

            DataSet dataset = new DataSet();

            adapter.Fill(dataset);

            DataTable table = dataset.Tables[0];

            DataRow row = table.NewRow();

            row["Id"] = product.Id;

            row["Name"] = product.Name;

            row["Description"] = product.Description;

            row["UnitPrice"] = product.UnitPrice;

            row["Quantity"] = product.Quantity;

            row["image"] = product.image;

            table.Rows.Add(row);

            adapter.Update(dataset);

            return true;

        }

        public static bool Update(Product product)

        {

            IDbConnection conn = new SqlConnection(conString);

            string query = "SELECT * FROM products_pratiksha";

            IDbCommand cmd = new SqlCommand(query, conn as SqlConnection);

            IDataAdapter adapter = new SqlDataAdapter(cmd as SqlCommand);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter as SqlDataAdapter);

            DataSet dataset = new DataSet();

            adapter.Fill(dataset);

            DataTable table = dataset.Tables[0];

            DataRowCollection collection = table.Rows;

            DataRow rowToUpdate = null;

            foreach (DataRow row in collection)

            {

                int rowId = int.Parse(row["id"].ToString());

                if (rowId == product.Id)

                {

                    rowToUpdate = row;

                    break;

                }

            }

            rowToUpdate["Description"] = product.Description;

            adapter.Update(dataset);

            return true;

        }

        public static void Delete(int id)

        {

            List<Product> products = new List<Product>();

            IDbConnection con = new SqlConnection(conString);

            string query = "SELECT * from products_pratiksha";

            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);

            DataSet dataSet = new DataSet();

            IDataAdapter adapter = new SqlDataAdapter(cmd as SqlCommand);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter as SqlDataAdapter);

            adapter.Fill(dataSet);

            DataTable table = dataSet.Tables[0];

            DataRowCollection rows = table.Rows;

            DataRow foundRow = null;

            foreach (DataRow row in rows)

            {

                int rowId = int.Parse(row["Id"].ToString());

                if (rowId == id)

                {

                    foundRow = row;

                }

            }

            foundRow.Delete();

            adapter.Update(dataSet);

        }

        public static int GetCount()

        {

            IDbConnection conn = new SqlConnection(conString);

            string query = "SELECT * FROM products_pratiksha";

            IDbCommand cmd = new SqlCommand(query, conn as SqlConnection);

            IDataAdapter adapter = new SqlDataAdapter(cmd as SqlCommand);

            DataSet ds = new DataSet();

            adapter.Fill(ds);

            DataTable table = ds.Tables[0];

            int count = table.Rows.Count;

            return count;

        }


        public static List<Product> GetAll()

        {

            List<Product> products = new List<Product>();

            IDbConnection con = new SqlConnection(conString);

            string query = "SELECT * from products_pratiksha";

            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);

            DataSet dataSet = new DataSet();

            IDataAdapter adapter = new SqlDataAdapter(cmd as SqlCommand);

            adapter.Fill(dataSet);

            DataTable table = dataSet.Tables[0];

            foreach (DataRow row in table.Rows)

            {

                int id = int.Parse(row["Id"].ToString());

                string name = row["Name"].ToString();

                string description = row["Description"].ToString();

                double unitPrice = double.Parse(row["UnitPrice"].ToString());

                int quantity = int.Parse(row["quantity"].ToString());

                string image = row["image"].ToString();

                Product product = new Product();

                product.Id = id;

                product.Name = name;

                product.Description = description;

                product.Quantity = quantity;

                product.image = image;

                products.Add(product);

            }

            return products;

        }

        public static Product GetById(int Id)

        {

            List<Product> products = new List<Product>();

            products = GetAll();

            Product theProduct = products.Find((product) => (product.Id == Id));

            return theProduct;

        }

    }

}
