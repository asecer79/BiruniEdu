using Microsoft.AspNetCore.Mvc;
using Week5.Data;
using Week5.Models.Entities;

namespace Week5.Controllers
{
    public class ProductsController : Controller
    {
        MyDatabaseContext db;

        public ProductsController(MyDatabaseContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var products = db.Products.ToList(); //"SELECT * FROM Products"


            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var product = new Product();

            return View(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {

            if (ModelState.IsValid)
            {
                db.Products.Add(product);  //INSERT INTO Products (Id, Name, Decription, Price, Brand) VALUES (.,,.,,)
                db.SaveChanges();

                return RedirectToAction("Index","Products");
            }



            return View(product);
        }
    }
}
