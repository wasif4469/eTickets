using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IProducerService
    {
        Task<IEnumerable<Producer>> GetAllAsync();

        Task<Producer> GetByIdAsync(int id);

        Task AddAsync(Producer producer);

        Task<Producer> UpdateAsync(int id, Producer NewProducer);

        Task DeleteAsync(int id);

    }
}
