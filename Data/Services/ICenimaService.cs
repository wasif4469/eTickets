using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface ICenimaService
    {
        Task<IEnumerable<Cenima>> GetAllAsync();

        Task<Cenima> GetByIdAsync(int id);

        Task AddAsync(Cenima cenima);

        Task<Cenima> UpdateAsync(int id, Cenima NewCenima);

        Task DeleteAsync(int id);
    }
}
