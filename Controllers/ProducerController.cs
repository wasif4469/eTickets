using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducerController : Controller
    {
        private readonly eTicketsDbContext _context;

        public ProducerController(eTicketsDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var AllMovies = await _context.Producers.ToListAsync();
            return View(AllMovies);
        }
    }
}
