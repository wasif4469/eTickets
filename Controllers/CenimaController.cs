using eTickets.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class CenimaController : Controller
    {
        private readonly eTicketsDbContext _context;

        public CenimaController(eTicketsDbContext context)
        {
            _context = context;
        }
    
        public IActionResult Index()
        {
            var AllCenimas = _context.Cenimas.ToList();
            return View(AllCenimas);
        }
    }
}
