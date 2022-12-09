using MoviesForYou.Application.API.Models;

namespace MoviesForYou.Application.API.Interfaces
{
    public interface IProducerServices
    {
        Task<bool> AddProducerAsync(Producer producer);
        Task<bool> UpdateProducerAsync(Producer producer);
        Task<List<Producer>> GetAllProducersAsync();
    }
}
