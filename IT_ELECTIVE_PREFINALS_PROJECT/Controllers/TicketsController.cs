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

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var tickets = await _context.Tickets
                .Include(t => t.Customer)
                .Include(t => t.Category)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            return View(tickets);
        }
    }
}