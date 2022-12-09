using MoviesForYou.Application.API.Models;

namespace MoviesForYou.Application.API.Interfaces
{
    public interface IActorServices
    {
        Task<bool> AddActor(Actor actor);
        Task<bool> UpdateActor(Actor actor);
    }
}
