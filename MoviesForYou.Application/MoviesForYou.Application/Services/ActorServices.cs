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
        private readonly ILogger<ProducerServices> loggerService;

        public ActorServices(MoviesDataContext _context, IValidationService _validationService, ILogger<ProducerServices> _loggerService)
        {
            context = _context;
            this.validationService = _validationService;
            this.loggerService = _loggerService;
        }
        public async Task<bool> AddActorAsync(Actor actor)
        {
            if(!validationService.isValidActor(actor))
            {
                loggerService.LogDebug("Failed the validation for adding actor", actor);
                throw new BadRequestException("Invalid Request parameter");
            }
            loggerService.LogInformation("Adding actor to the database....");
            try
            {
                await context.Actors.AddAsync(actor);
                await context.SaveChangesAsync();

            }
            catch (Exception exception)
            {
                loggerService.LogDebug(exception, "Failed adding the actor into the system");
                throw new InternalServerException(exception.Message);
            }
            loggerService.LogInformation("Successfully added actor to the database....");
            return true;
        }

        public async Task<bool> UpdateActorAsync(Actor actor)
        {
            if(actor.ActorId <= 0 && !validationService.isValidActor(actor))
            {
                loggerService.LogDebug("Failed the validation for updating actor", actor);
                throw new BadRequestException("Invalid Request parameter");
            }
            try
            {
                loggerService.LogInformation("Updating actor to the database....");
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
                    throw new NotFoundException("The record to update doesn't exist in the system");
                }
            }
            catch (NotFoundException exception)
            {
                loggerService.LogDebug(exception, "Actor to update doesn't exist into the system");
                throw new NotFoundException(exception.Message);
            }
            catch (Exception exception)
            {
                loggerService.LogDebug(exception, "Failed updating the actor into the database");
                throw new InternalServerException(exception.Message);
            }
            loggerService.LogInformation("Updated actor successfully to the database....");
            return true;
        }

        public async Task<List<Actor>> GetAllActorsAsync()
        {
            List<Actor> actors = null;
            try
            {
                loggerService.LogInformation("Retrieving actors from the database....");
                actors = await context.Actors.ToListAsync<Actor>();
            }
            catch (Exception exception)
            {
                loggerService.LogDebug(exception, "Failed retrieving the actors from the system");
                throw new InternalServerException(exception.Message);
            }
            loggerService.LogInformation("Successfully retrieved actors from the database....");
            return actors;
        }
    }
}
