using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ActorController : Controller
    {
        private readonly eTicketsDbContext _context;

        public ActorController(eTicketsDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var AllMovies = await _context.Actors.ToListAsync();
            return View(AllMovies);
        }
    }
}
