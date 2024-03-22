using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerService _service;

        public ProducerController(IProducerService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var AllProducers = await _service.GetAllAsync();
            return View(AllProducers);
        }

        //HTTPGET: create

        public async Task<IActionResult>Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create([Bind("ProfilePictureName,ProducerName,Bio")] Producer producer) 
        {
            if(!ModelState.IsValid) { return View(); }

            var result = _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult>Details(int id) 
        {
            var result = _service.GetByIdAsync(id);
            if (result != null) { return NotFound(); }
            return View(result);
        }

        //HTTPGET: EDIT

        public async Task<IActionResult>Edit(int id) 
        {
            var result = _service.GetByIdAsync(id);
            if (result != null) { return NotFound(); }
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producer producer) 
        {
           if (id != producer.ProducerId) {return NotFound(); }
           if (!ModelState.IsValid) { return View(); }
            await _service.UpdateAsync(id, producer);
            return RedirectToAction(nameof(Index));
        }

        //HTTPGET: DELETE

        public async Task<IActionResult> Delete(int id) 
        {
            var AllProducers = await _service.GetByIdAsync(id);
            if (AllProducers != null) { return View("NotFound"); }
            return View(AllProducers);
        }

        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var AllProducers = await _service.GetByIdAsync(id);
            if (AllProducers != null) { return View("NotFound"); }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));    
        }
    }
}
