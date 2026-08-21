using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IT_ELECTIVE_PREFINALS_PROJECT.Data;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Controllers
{
    public class TeamsController : Controller
    {
        private readonly HelpDeskContext _context;

        public TeamsController(HelpDeskContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var teams = await _context.Teams
                .Include(t => t.Department)
                .Include(t => t.TeamMembers)
                    .ThenInclude(tm => tm.Employee)
                .OrderBy(t => t.Name)
                .ToListAsync();

            return View(teams);
        }
    }
}