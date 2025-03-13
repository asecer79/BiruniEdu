using BiruniEdu.WebUI.DataAccess.Context;
using BiruniEdu.WebUI.DataAccess.Dal.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BiruniEdu.WebUI.Controllers
{
    public class FacultiesController : Controller
    {
        private IFacultyDal _facultyDal;
        
        public FacultiesController(IFacultyDal facultyDal)
        {
            _facultyDal = facultyDal;
        }
        public IActionResult Index()
        {
            var records = _facultyDal.GetList().ToList();
            
            return View(records);
        }
    }
}
