using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MovieController : Controller
    {
        private readonly eTicketsDbContext _context;

        public MovieController(eTicketsDbContext context)
        {
            _context = context;
        }
    
        public async Task<IActionResult>Index()
        {
            var AllMovies = await _context.Movies.Include(n => n.Cenima).OrderBy(n => n.MovieName).ToListAsync();
            return View(AllMovies);
        }
    }
}
