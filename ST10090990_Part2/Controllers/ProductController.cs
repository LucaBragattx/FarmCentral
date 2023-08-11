using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ST10090990_Part2.DataLogic;
using ST10090990_Part2.Models;

namespace ST10090990_Part2.Controllers
{
    public class ProductController : Controller
    {
        DBLogic dbHelper;

        public ProductController(IConfiguration config)
        {
            dbHelper = new DBLogic(config);
        }

        // GET: Farmer
        public ActionResult DisplayProducts(string id)
        {
            List<Products> pList = dbHelper.AllFarmerProducts(id);

            return View(pList);
        }

        public ActionResult ViewProductsByFarmer(string farmerId)
        {
            List<Products> products = dbHelper.GetProductsByFarmer(farmerId);
            return View(products);
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductController/Details/5
        public ActionResult Details(string id)
        {
            Products prod= dbHelper.GetProducts(id);

           
            return View(prod);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
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

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
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
