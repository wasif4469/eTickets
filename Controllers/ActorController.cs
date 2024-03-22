using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorsService _service;

        public ActorController(IActorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var AllActors = await _service.GetAllAsync();
            return View(AllActors);
        }


        //Get request: Create new Entity(Actor)

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create([Bind("ProfilePictureURL,ActorName,bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task <IActionResult> Details(int id) 
        {
            var ActorDetails = await _service.GetByIdAsync(id);
            if (ActorDetails == null) return View("NotFound");
            return View(ActorDetails);
        }

        //HTTPGet Edit/1
        public async Task<IActionResult>Edit(int id)
        {
            var ActorDetails = await _service.GetByIdAsync(id);
            if (ActorDetails == null) return View("NotFound");
            return View(ActorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Actor actor)
        {
            if (id != actor.ActorId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        //HTTPGet Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var ActorDetails = await _service.GetByIdAsync(id);
            if (ActorDetails == null) return View("NotFound");
            return View(ActorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var ActorDetails = await _service.GetByIdAsync(id);
            if (ActorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
