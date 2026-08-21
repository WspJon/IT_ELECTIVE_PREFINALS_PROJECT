using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IT_ELECTIVE_PREFINALS_PROJECT.Data;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly HelpDeskContext _context;

        public DepartmentsController(HelpDeskContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _context.Departments
                .Include(d => d.Employees)
                .OrderBy(d => d.Name)
                .ToListAsync();

            return View(departments);
        }
    }
}