using eTickets.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class MovieController : Controller
    {
        private readonly eTicketsDbContext _context;

        public MovieController(eTicketsDbContext context)
        {
            _context = context;
        }
    
        public IActionResult Index()
        {
            var AllMovies = _context.Movies.ToList();   
            return View();
        }
    }
}
