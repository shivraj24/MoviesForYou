using MoviesForYou.Application.API.Models;

namespace MoviesForYou.Application.API.Interfaces
{
    public interface IActorServices
    {
        Task<bool> AddActorAsync(Actor actor);
        Task<bool> UpdateActorAsync(Actor actor);
        Task<List<Actor>> GetAllActorsAsync();
    }
}
