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
                .OrderByDescending(t => t.TicketId)
                .ToListAsync();

            return View(tickets);
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .Include(t => t.Customer)
                .Include(t => t.TicketComments)
                    .ThenInclude(c => c.Employee)
                .Include(t => t.TicketAttachments)
                .Include(t => t.TicketTags)
                    .ThenInclude(tt => tt.Tag)
                .Include(t => t.TicketAssignments)
                    .ThenInclude(ta => ta.Employee)
                .FirstOrDefaultAsync(m => m.TicketId == id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        public async Task<IActionResult> Unassigned()
        {
            var unassignedTickets = await _context.Tickets
                .Include(t => t.Customer)
                .Include(t => t.Category)
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Where(t => !t.TicketAssignments.Any() || t.TicketAssignments.All(ta => ta.UnassignedAt != null))
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            return View(unassignedTickets);
        }
    }
}