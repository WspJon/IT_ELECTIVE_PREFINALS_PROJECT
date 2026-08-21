// GET: Tickets/Unassigned
using Microsoft.AspNetCore.Mvc;

public async Task<IActionResult> Unassigned()
{
    var unassignedTickets = await _context.Tickets
        .Include(t => t.Customer)
        .Include(t => t.Category)
        .Where(t => !t.TicketAssignments.Any())
        .OrderByDescending(t => t.CreatedAt)
        .ToListAsync();

    return View(unassignedTickets);
}