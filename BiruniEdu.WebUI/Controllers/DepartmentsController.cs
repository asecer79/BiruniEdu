using BiruniEdu.Business.Abstract;
using BiruniEdu.DataAccess.Dal.Abstract;
using BiruniEdu.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BiruniEdu.WebUI.Controllers
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        IFacultyService _faultyService;
        IDepartmentService _departmentService;
        public DepartmentsController(IDepartmentService departmentService, IFacultyService faultyService)
        {
            _departmentService = departmentService;
            _faultyService = faultyService;
        }

        // GET: Departments
        //[AllowAnonymous]
        public Task<IActionResult> Index()
        {
            var data = _departmentService.GetList().ToList();
            return Task.FromResult<IActionResult>(View(data));
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = _departmentService.GetList()
                .FirstOrDefault(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["FacultyId"] = new SelectList(_departmentService.GetList(), 
"Id", "FacultyName");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public async Task<IActionResult> Create([Bind("Id,DepartmentName,FacultyId,HeadOfDepartment")] Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentService.Create(department);
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacultyId"] = new SelectList(_faultyService.GetList(), "Id", "FacultyName", department.FacultyId);
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = _departmentService.Get(p=>p.Id==id);
            if (department == null)
            {
                return NotFound();
            }
            ViewData["FacultyId"] = new SelectList(_faultyService.GetList(), "Id", "FacultyName", department.FacultyId);
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,DepartmentName,FacultyId,HeadOfDepartment")] Department department)
        //{
        //    if (id != department.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(department);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DepartmentExists(department.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "FacultyName", department.FacultyId);
        //    return View(department);
        //}

        //// GET: Departments/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var department = await _context.Departments
        //        .Include(d => d.Faculty)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (department == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(department);
        //}

        //// POST: Departments/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var department = await _context.Departments.FindAsync(id);
        //    if (department != null)
        //    {
        //        _context.Departments.Remove(department);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool DepartmentExists(int id)
        //{
        //    return _context.Departments.Any(e => e.Id == id);
        //}
    }
}
