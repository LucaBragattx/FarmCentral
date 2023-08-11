using ST10090990_Part2.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ST10090990_Part2.DataLogic
{
    public class DBLogic
    {
        private string conn;
        private IConfiguration _conn;

        public DBLogic(IConfiguration configuration)
        {
            _conn = configuration;
            conn = _conn.GetConnectionString("azureDBConnection");

        }

        public List<Farmers> AllFarmers()
        {
            List<Farmers> fList = new List<Farmers>();
            SqlConnection myConn = new SqlConnection(conn);
            SqlDataAdapter myAdapter = new SqlDataAdapter("SELECT * FROM Farmers", myConn);
            DataTable dt = new DataTable();
            DataRow dr;
            string name, password;
            string id;

            myConn.Open();
            myAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];


                    fList.Add(new Farmers(id = (string)dr[0], name = (string)dr[1], password = (string)dr[2]));
                }
            }

            myConn.Close();
            return fList;
        }
        public List<Employees> AllEmployees()
        {
            List<Employees> eList = new List<Employees>();
            SqlConnection myConn = new SqlConnection(conn);
            SqlDataAdapter myAdapter = new SqlDataAdapter("SELECT * FROM Employees", myConn);
            DataTable dt = new DataTable();
            DataRow dr;
            string name, password;
            string id;

            myConn.Open();
            myAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];


                    eList.Add(new Employees(id = (string)dr[0], name = (string)dr[1], password = (string)dr[2]));
                }
            }

            myConn.Close();
            return eList;
        }

        public Farmers GetFarmer(string id)
        {
            Farmers farm = new Farmers();
            SqlConnection myConn = new SqlConnection(conn);
            SqlCommand cmdSelect = new SqlCommand($"SELECT * FROM Farmers where farmer_id = '{id}'", myConn);
            myConn.Open();
            using (SqlDataReader reader = cmdSelect.ExecuteReader())
            {
                while (reader.Read())
                {
                    farm = new Farmers((string)reader[0], (string)reader[1], (string)reader[2]);

                }
            }
            myConn.Close();
            return farm;
        }

        public string GetFarmerID(string name)
        {
            string id = "";
            SqlConnection myConn = new SqlConnection(conn);
            SqlCommand cmdSelect = new SqlCommand($"SELECT farmer_id FROM Farmers where farmer_username = '{name}'", myConn);
            myConn.Open();
            using (SqlDataReader reader = cmdSelect.ExecuteReader())
            {
                while (reader.Read())
                {
                    id = (string)reader[0];

                }
            }
            myConn.Close();
            return id;
        }

        public void AddFarmer(Farmers farmers)
        {
            using(SqlConnection myConnection = new SqlConnection(conn)) 
            {
                SqlCommand cmdInsert = new SqlCommand($"INSERT INTO FARMERS " + $"VALUES('{farmers.FarmerID}', '{farmers.FarmerName}', '{farmers.FarmerPassword}')", myConnection);
                myConnection.Open();
                cmdInsert.ExecuteNonQuery();
            }

            /*
             * SqlTransaction = myTransaction
             * myTransaction = myConnection.BeginTransaction();
             * cmd.Transaction = myTransaction;
             * try
             * {
             * x = cmd.ExecuteNonquery();
             * myTransaction.Commit();
             * }
             * catch(exception)
             * {
             * myTransaction.Rollback();
             * }
             * Finally
             * {
             * myConnection.Close();
             * }*/
        }

        public Products GetProducts(string id)
        {
            Products prod = new Products();
            SqlConnection myConn = new SqlConnection(conn);
            SqlCommand cmdSelect = new SqlCommand($"SELECT * FROM Products where product_id = '{id}'", myConn);
            myConn.Open();
            using (SqlDataReader reader = cmdSelect.ExecuteReader())
            {
                while (reader.Read())
                {
                    prod = new Products((string)reader[0], (string)reader[1], (string)reader[2], (DateTime)reader[3]);

                }
            }
            myConn.Close();
            return prod;
        }
        public List<Products> AllFarmerProducts(string id)
        {
            List<Products> pList = new List<Products>();
            SqlConnection myConn = new SqlConnection(conn);
            SqlDataAdapter myAdapter = new SqlDataAdapter($"SELECT * FROM Products where farmer_id = '{id}'", myConn) ;
            DataTable dt = new DataTable();
            DataRow dr;
            string name;
            string id1;
            DateTime dateAdded;

            myConn.Open();
            myAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];


                    pList.Add(new Products(id1 = (string)dr[0], id1 = (string)dr[1], name = (string)dr[2], dateAdded = (DateTime)dr[3]));
                }
            }

            myConn.Close();
            return pList;
        }

        public List<Products> GetProductsByFarmer(string farmerId)
        {
            List<Products> products = new List<Products>();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = $"SELECT * FROM Products WHERE farmer_id = '{farmerId}'";
                SqlCommand command = new SqlCommand(query, connection);
                
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Products((string)reader[0], (string)reader[1],(string)reader[2], (DateTime)reader[3]));
                   
                    
                }
            }
            return products;
        }

        public List<Products> GetDate(DateTime start, DateTime end)
        {
            List<Products> lc = new List<Products>();
            using (SqlConnection con = new SqlConnection(conn))
            {
                string query = $"SELECT * FROM Products where date_added between '{start} ' and '{end}'";
                SqlCommand command = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    lc.Add(new Products { ProductID = (string)(dr[0]), FarmerID = (string)(dr[1]), ProductName = (string)(dr[2]), DateAdded = (DateTime)(dr[3]) });
                }
            }
            return lc;
            
            /*string query = $"SELECT * FROM Products where date_added between '{ start} ' and '{end}'";
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<Products> lc = new List<Products>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lc.Add(new Products { ProductID = (string)(dr[0]), FarmerID = (string)(dr[1]), ProductName = (string)(dr[2]), DateAdded = (DateTime)(dr[3]) });
            }
            con.Close();
            return lc;*/

        }
    }
}
