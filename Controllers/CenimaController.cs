using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class CenimaController : Controller
    {
        private readonly ICenimaService _service;

        public CenimaController(ICenimaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var AllCenimas = await _service.GetAllAsync();
            return View(AllCenimas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Create([Bind("CenimaLogo,CenimaName,Description")] Cenima cenima) 
        {
            if(!ModelState.IsValid) 
            {
                return View(cenima);
            }
            await _service.AddAsync(cenima);
            return View(nameof(Index));
            
        }

        public async Task <IActionResult> Details(int id)
        {
            var CenimaDetails = await _service.GetByIdAsync(id);
            if (CenimaDetails == null) return View("NotFound");
            return View(CenimaDetails);
        }

        //HTTPGET: EDIT/1
        public async Task<IActionResult>Edit(int id)
        {
            var CenimaDetails = await _service.GetByIdAsync(id);
            if (CenimaDetails == null) return View("NotFound");
            return View(CenimaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Cenima cenima)
        {
            if (id != cenima.CenimaID)
            {
                return View("NotFound");
            }

            if (!ModelState.IsValid)
            {
                return View(cenima);
            }

            await _service.GetByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //HTTPGet Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var CenimaDetails = await _service.GetByIdAsync(id);
            if (CenimaDetails == null) return View("NotFound");
            return View(CenimaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var CenimaDetails = _service.GetByIdAsync(id);
            if (CenimaDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return View(CenimaDetails);
            
        }
    }
}
