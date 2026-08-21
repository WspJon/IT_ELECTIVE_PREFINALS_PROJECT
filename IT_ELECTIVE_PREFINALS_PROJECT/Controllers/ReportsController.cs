using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IT_ELECTIVE_PREFINALS_PROJECT.Data;
using IT_ELECTIVE_PREFINALS_PROJECT.Models;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Controllers
{
    public class ReportsController : Controller
    {
        private readonly HelpDeskContext _context;

        public ReportsController(HelpDeskContext context)
        {
            _context = context;
        }

        // Query: Employee Workload
        public async Task<IActionResult> EmployeeWorkload()
        {
            var report = await _context.Employees
                .Where(e => e.IsActive == 1)
                .Select(e => new EmployeeWorkloadViewModel
                {
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.FirstName + " " + e.LastName,
                    DepartmentName = e.Department != null ? e.Department.Name : "No Dept",
                    ActiveTicketCount = _context.Set<TeamMember>()
                        .Where(tm => tm.EmployeeId == e.EmployeeId)
                        .Count()
                })
                .OrderByDescending(r => r.ActiveTicketCount)
                .ToListAsync();

            return View(report);
        }
    }
}