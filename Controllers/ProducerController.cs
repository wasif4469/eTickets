using eTickets.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ProducerController : Controller
    {
        private readonly eTicketsDbContext _context;

        public ProducerController(eTicketsDbContext context)
        {
            _context = context;
        }
    
        public IActionResult Index()
        {
            var AllProducers = _context.Producers.ToList();
            return View();
        }
    }
}
