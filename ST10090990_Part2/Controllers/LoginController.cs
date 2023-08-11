using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;
using ST10090990_Part2.DataLogic;
using ST10090990_Part2.Models;
namespace ST10090990_Part2.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        // GET: LoginController

        DBLogic dbHelper;

        public LoginController(IConfiguration config)
        {
            dbHelper = new DBLogic(config);
        }

        void connectionString()
        {
            con.ConnectionString = "Server=tcp:parttwo.database.windows.net,1433;Initial Catalog=FarmCentral;Persist Security Info=False;User ID=lucabragatto;Password=ilsanto7!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
           
        }

        [HttpPost]
        public ActionResult Verify(Login log)
        {
            if (log.User.Equals("Employee"))
            {
                connectionString();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = $"SELECT * FROM Employees where emplyee_username = '{log.Name}' and employee_password = '{log.Password}' ";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    con.Close();
                    return RedirectToAction("DisplayFarmers", "Farmer");
                }
                else
                {
                    con.Close();
                    return View("Error");
                }
            }else if (log.User.Equals("Farmer"))
            {
                connectionString();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = $"SELECT * FROM Farmers where farmer_username = '{log.Name}' and farmer_password = '{log.Password}' ";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string id = dbHelper.GetFarmerID(log.Name);
                    con.Close();
                    return RedirectToAction("DisplayProducts", "Product", new { id=id});
                       
                }
                else
                {
                    con.Close();
                    return View("Error");
                }
            }
            return View("Error");

        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
