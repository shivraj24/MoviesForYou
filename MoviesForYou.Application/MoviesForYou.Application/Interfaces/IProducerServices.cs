using MoviesForYou.Application.API.Models;

namespace MoviesForYou.Application.API.Interfaces
{
    public interface IProducerServices
    {
        Task<bool> AddProducer(Producer producer);
        Task<bool> UpdateProducer(Producer producer);

    }
}
