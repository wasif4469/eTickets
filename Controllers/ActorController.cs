using eTickets.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorController : Controller
    {
        private readonly eTicketsDbContext _context;

        public ActorController(eTicketsDbContext context)
        {
            _context = context;
        }
    
        public IActionResult Index()
        {
            var AllActors = _context.Actors.ToList();
            return View();
        }
    }
}
