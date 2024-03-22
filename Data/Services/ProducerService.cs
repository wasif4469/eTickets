using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ProducerService
    {
        private readonly eTicketsDbContext _context;

        public ProducerService(eTicketsDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Producer producer)
        {
            await _context.Producers.AddAsync(producer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id) 
        {
            var result = await _context.Producers.FirstOrDefaultAsync(n => n.ProducerId == id);
             _context.Producers.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Producer>>GetAllAsync() 
        {
            var result = await _context.Producers.ToListAsync();
            return result;
        }

        public async Task<Producer> GetByIdAsync(int id) 
        {
            var result = await _context.Producers.FirstOrDefaultAsync(n => n.ProducerId == id);
            return result;
        }

        public async Task<Producer> UpdateAsync(int id, Producer NewProducer) 
        {
            var result = await _context.Producers.FirstOrDefaultAsync(n => n.ProducerId == id);
            if (result == null)
            {
                throw new Exception("Producder Not Found");
            }

            result.ProfilePictureName = NewProducer.ProfilePictureName;
            result.ProducerName = NewProducer.ProducerName;
            result.Bio = NewProducer.Bio;

            await _context.SaveChangesAsync();
            return result;
        }

    }
}
