using Microsoft.AspNetCore.Mvc;
using Week5.Data;

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
    }
}
