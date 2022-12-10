using Microsoft.EntityFrameworkCore;
using MoviesForYou.Application.API.Data;
using MoviesForYou.Application.API.ExceptionHandler;
using MoviesForYou.Application.API.Interfaces;
using MoviesForYou.Application.API.Models;

namespace MoviesForYou.Application.API.Services
{
    public class ActorServices : IActorServices
    {
        private readonly MoviesDataContext context;
        private readonly IValidationService validationService;
        public ActorServices(MoviesDataContext _context, IValidationService _validationService)
        {
            context = _context;
            this.validationService = _validationService;
        }
        public async Task<bool> AddActorAsync(Actor actor)
        {
            if(!validationService.isValidActor(actor))
            {
                throw new BadRequestException("Invalid Request parameter");
            }
            try
            {
                await context.Actors.AddAsync(actor);
                await context.SaveChangesAsync();

            }
            catch (Exception exception)
            {
                throw new InternalServerException(exception.Message);
            }
            return true;
        }

        public async Task<bool> UpdateActorAsync(Actor actor)
        {
            if(actor.ActorId <= 0 && !validationService.isValidActor(actor))
            {
                throw new BadRequestException("Invalid Request parameter");
            }
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
                    throw new NotFoundException("the record to update doesn't exist in the system");
                }
            }
            catch (NotFoundException exception)
            {
                throw new NotFoundException(exception.Message);
            }
            catch (Exception exception)
            {
                throw new InternalServerException(exception.Message);
            }
            return true;
        }

        public async Task<List<Actor>> GetAllActorsAsync()
        {
            try
            {
                return await context.Actors.ToListAsync<Actor>();
            }
            catch (Exception exception)
            {
                throw new InternalServerException(exception.Message);
            }
        }
    }
}
