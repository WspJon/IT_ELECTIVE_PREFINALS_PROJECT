using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IT_ELECTIVE_PREFINALS_PROJECT.Data;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly HelpDeskContext _context;

        public EmployeesController(HelpDeskContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees
                .Include(e => e.Department)
                .OrderBy(e => e.LastName)
                .ThenBy(e => e.FirstName)
                .ToListAsync();

            return View(employees);
        }
    }
}