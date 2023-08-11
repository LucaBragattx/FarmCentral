using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ST10090990_Part2.DataLogic;
using ST10090990_Part2.Models;

namespace ST10090990_Part2.Controllers
{
    public class Farmer : Controller
    {
        DBLogic dbHelper;

        public Farmer(IConfiguration config)
        {
            dbHelper = new DBLogic(config);
        }

        // GET: Farmer
        public ActionResult DisplayFarmers()
        {
            List<Farmers> fList = dbHelper.AllFarmers();

            return View(fList);
        }

        // GET: Farmer/Details/5
        public ActionResult Details(string id)
        {
            Farmers farm = dbHelper.GetFarmer(id);
            

            return View(farm);
        }

        // GET: Farmer/Products/5
        public ActionResult Products(string id)
        {
            Products prod = dbHelper.GetProducts(id);
            

            return RedirectToAction("DisplayProducts","Product", new {id=id});
        }
        /*  public ActionResult Products(string id, string productName, DateTime start, DateTime end)
        {
            List<Products> farm = dbHelper.GetProductsByFarmer(id);
            

            if(!string.IsNullOrEmpty(productName))
            {
                farm = farm.Where( p => p.ProductName.Contains(productName)).ToList();
                ViewBag.FilteredProductName = productName;
            }
            DateTime temp;

            if (!DateTime.TryParse(start.ToString(), out temp) && !DateTime.TryParse(end.ToString(), out temp))
            {
                ModelState.Clear();
                farm = dbHelper.GetDate(start, end);
                //farm = farm.Where( p => (start <= p.DateAdded && start <= end)).Select(x => $"id = { id = x.FarmerID}");
                ViewBag.FilteredProductStart = start;
                ViewBag.FilteredProductEnd= end;
            }
            

            return View(farm);
        }
*/




        // GET: Farmer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Farmer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                string id = collection["txtFarmerID"];
                string name = collection["txtFarmerName"];
                string pass = collection["txtFarmerPass"];

                Farmers farm = new Farmers(id, name, pass);
                dbHelper.AddFarmer(farm);
                return RedirectToAction(nameof(DisplayFarmers));
            }
            catch
            {
                return View();
            }
        }

        // GET: Farmer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Farmer/Edit/5
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

        // GET: Farmer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Farmer/Delete/5
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
