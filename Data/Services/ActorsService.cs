using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly eTicketsDbContext _context;

        public ActorsService(eTicketsDbContext context)
        {
            _context= context;
        }
        public async Task AddAsync(Actor actor)
        {
           await _context.Actors.AddAsync(actor);
           await _context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(int id)
        {
            var Result = await _context.Actors.FirstOrDefaultAsync(n => n.ActorId == id);
            _context.Actors.Remove(Result);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Actor>>GetAllAsync()
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        public async Task <Actor> GetByIdAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.ActorId == id);
            return result; 
            
        }

        public async Task<Actor> UpdateAsync(int id, Actor actor)
        {
            var existingActor = await _context.Actors.FindAsync(id);
            if (existingActor == null)
            {
                throw new Exception("Actor not found");
            }

            existingActor.ActorName = actor.ActorName;
            existingActor.ProfilePictureURL = actor.ProfilePictureURL;
            existingActor.bio = actor.bio;

            await _context.SaveChangesAsync();
            return existingActor;
        }

    }
}
