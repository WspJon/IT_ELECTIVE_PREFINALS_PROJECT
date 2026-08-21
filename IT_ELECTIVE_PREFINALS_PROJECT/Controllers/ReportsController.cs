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

        // 1. Employee Workload
        public async Task<IActionResult> EmployeeWorkload()
        {
            var report = await _context.Employees
                .Where(e => e.IsActive == 1)
                .Select(e => new EmployeeWorkloadViewModel
                {
                    EmployeeId = e.Id,
                    EmployeeName = e.FirstName + " " + e.LastName,
                    DepartmentName = e.Department != null ? e.Department.Name : "No Dept",
                    ActiveTicketCount = e.TicketAssignments.Count
                })
                .OrderByDescending(r => r.ActiveTicketCount)
                .ToListAsync();

            return View(report);
        }

        // 2. Department Workload / Headcount
        public async Task<IActionResult> DepartmentWorkload()
        {
            var report = await _context.Departments
                .Select(d => new DepartmentWorkloadViewModel
                {
                    DepartmentName = d.Name,
                    DepartmentCode = d.Name,
                    EmployeeCount = d.Employees.Count
                })
                .OrderByDescending(r => r.EmployeeCount)
                .ToListAsync();

            return View(report);
        }

        // 3. Unassigned Tickets
        public async Task<IActionResult> UnassignedTickets()
        {
            var tickets = await _context.Tickets
                .Include(t => t.Customer)
                .Include(t => t.Category)
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Where(t => !t.TicketAssignments.Any() || t.TicketAssignments.All(ta => ta.UnassignedAt != null))
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            return View(tickets);
        }

        // 4. Multiple Assignees
        public async Task<IActionResult> MultipleAssignees()
        {
            var tickets = await _context.Tickets
                .Include(t => t.Customer)
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Include(t => t.TicketAssignments)
                    .ThenInclude(ta => ta.Employee)
                .Where(t => t.TicketAssignments.Count > 1)
                .OrderByDescending(t => t.TicketAssignments.Count)
                .ToListAsync();

            return View(tickets);
        }

        // 5. Primary Assignee
        public async Task<IActionResult> PrimaryAssignee()
        {
            var tickets = await _context.Tickets
                .Include(t => t.Customer)
                .Include(t => t.Status)
                .Include(t => t.TicketAssignments)
                    .ThenInclude(ta => ta.Employee)
                .Select(t => new PrimaryAssigneeViewModel
                {
                    TicketId = t.Id,
                    Title = t.Subject,
                    CustomerName = t.Customer != null ? t.Customer.ContactName : "No Customer",
                    StatusName = t.Status != null ? t.Status.Name : "No Status",
                    PrimaryTechnician = t.TicketAssignments
                        .Where(ta => ta.IsPrimary == 1 && ta.UnassignedAt == null)
                        .Select(ta => ta.Employee != null ? ta.Employee.FirstName + " " + ta.Employee.LastName : "Unassigned")
                        .FirstOrDefault() ?? "Unassigned"
                })
                .OrderBy(t => t.TicketId)
                .ToListAsync();

            return View(tickets);
        }

        // 6. Category Hierarchy
        public async Task<IActionResult> CategoryHierarchy()
        {
            var categories = await _context.TicketCategories
                .Include(c => c.ParentCategory)
                .Include(c => c.SubCategories)
                .OrderBy(c => c.ParentCategoryId)
                .ThenBy(c => c.Name)
                .ToListAsync();

            return View(categories);
        }
    }
}