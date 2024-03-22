using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class CenimaServices
    {
        private readonly eTicketsDbContext _context;

        public CenimaServices(eTicketsDbContext context)
        {
            _context= context;
        }
        public async Task AddAsync(Cenima cenima)
        {
           await _context.Cenimas.AddAsync(cenima);
           await _context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(int id)
        {
            var Result = await _context.Cenimas.FirstOrDefaultAsync(n => n.CenimaID == id);
            _context.Cenimas.Remove(Result);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Cenima>>GetAllAsync()
        {
            var result = await _context.Cenimas.ToListAsync();
            return result;
        }

        public async Task<Cenima>GetByIdAsync(int id)
        {
            var result = await _context.Cenimas.FirstOrDefaultAsync(n => n.CenimaID == id);
            return result; 
            
        }

        public async Task<Cenima> UpdateAsync(int id, Cenima cenima)
        {
            var existingCenima = await _context.Cenimas.FirstOrDefaultAsync(n => n.CenimaID == id);
            if (existingCenima == null)
            {
                throw new Exception("Cenima not found");
            }

            existingCenima.CenimaName = cenima.CenimaName;
            existingCenima.CenimaLogo = cenima.CenimaLogo;
            existingCenima.Description = cenima.Description;

            await _context.SaveChangesAsync();
            return existingCenima;
        }
    }
}
