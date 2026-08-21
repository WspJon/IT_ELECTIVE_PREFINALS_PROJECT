using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IT_ELECTIVE_PREFINALS_PROJECT.Data;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Controllers
{
    public class TicketsController : Controller
    {
        private readonly HelpDeskContext _context;

        public TicketsController(HelpDeskContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tickets = await _context.Tickets
                .Include(t => t.Customer)
                .Include(t => t.Category)
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .OrderByDescending(t => t.Id)
                .ToListAsync();

            return View(tickets);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var ticket = await _context.Tickets
                .Include(t => t.Customer)
                .Include(t => t.Category)
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Include(t => t.TicketAssignments).ThenInclude(ta => ta.Employee)
                .Include(t => t.TicketTags).ThenInclude(tt => tt.Tag)
                .Include(t => t.TicketComments).ThenInclude(tc => tc.Employee)
                .Include(t => t.TicketAttachments)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (ticket == null) return NotFound();

            return View(ticket);
        }
    }
}