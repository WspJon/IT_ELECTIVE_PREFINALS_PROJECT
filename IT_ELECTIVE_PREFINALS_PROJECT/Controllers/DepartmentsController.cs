using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IT_ELECTIVE_PREFINALS_PROJECT.Data;
using IT_ELECTIVE_PREFINALS_PROJECT.Models.ViewModels;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly HelpDeskContext _context;

        public DepartmentsController(HelpDeskContext context)
        {
            _context = context;
        }

        // GET: Departments/Workload
        public async Task<IActionResult> Workload()
        {
            var workloadData = await _context.Departments
                .Select(d => new DepartmentWorkloadViewModel
                {
                    DepartmentId = d.DepartmentId,
                    DepartmentName = d.DepartmentName,
                    Location = d.Location,
                    EmployeeCount = d.Employees.Count()
                })
                .OrderByDescending(w => w.EmployeeCount)
                .ToListAsync();

            return View(workloadData);
        }
    }
}