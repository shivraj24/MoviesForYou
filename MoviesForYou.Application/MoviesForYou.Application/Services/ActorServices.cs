using Microsoft.EntityFrameworkCore;
using MoviesForYou.Application.API.Data;
using MoviesForYou.Application.API.Interfaces;
using MoviesForYou.Application.API.Models;

namespace MoviesForYou.Application.API.Services
{
    public class ActorServices : IActorServices
    {
        private readonly MoviesDataContext context;
        public ActorServices(MoviesDataContext _context)
        {
            context = _context;
        }
        public async Task<bool> AddActorAsync(Actor actor)
        {
            try
            {
                await context.Actors.AddAsync(actor);
                await context.SaveChangesAsync();

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateActorAsync(Actor actor)
        {
            try
            {
                var existingActor = await context.Actors.FindAsync(actor.ActorId);
                if(existingActor != null)
                {
                    existingActor.Name = actor.Name;
                    existingActor.Bio = actor.Bio;
                    existingActor.Gender = actor.Gender;
                    existingActor.DateOfBirth = actor.DateOfBirth;
                    await context.SaveChangesAsync();
                }
                else
                {
                    return false;
                }
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Actor>> GetAllActorsAsync()
        {
            try
            {
                return await context.Actors.ToListAsync<Actor>();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
