using Microsoft.EntityFrameworkCore;
using MoviesForYou.Application.API.Data;
using MoviesForYou.Application.API.ExceptionHandler;
using MoviesForYou.Application.API.Interfaces;
using MoviesForYou.Application.API.Models;
using System;

namespace MoviesForYou.Application.API.Services
{
    public class ProducerServices : IProducerServices
    {
        private readonly MoviesDataContext context;
        private readonly IValidationService validationService;
        private readonly ILogger<ProducerServices> loggerService;

        public ProducerServices(MoviesDataContext _context,IValidationService _validationService, ILogger<ProducerServices> _loggerService)
        {
            this.context = _context;
            this.validationService = _validationService;
            this.loggerService = _loggerService;
        }
        public async Task<bool> AddProducerAsync(Producer producer)
        {
            if(!validationService.isValidProducer(producer))
            {
                loggerService.LogDebug("Failed the validation for adding producer",producer);
                throw new BadRequestException("Invalid Request Paramters");
            }
            try
            {
                loggerService.LogInformation("Adding producer to the database....");
                await context.Produers.AddAsync(producer);
                await context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                loggerService.LogDebug(exception,"Failed adding the producer into the system");
                throw new InternalServerException(exception.Message);
            }
            loggerService.LogInformation("Successfully added producer to the database....");
            return true;
        }

        public async Task<bool> UpdateProducerAsync(Producer producer)
        {
            if(producer.ProducerId <= 0  && !validationService.isValidProducer(producer))
            {
                loggerService.LogDebug("Failed the validation for updating producer",producer);
                throw new BadRequestException("Invalid Request parameters");
            }
            try
            {
                loggerService.LogInformation("Updating producer to the database....");
                var existingProducer = await context.Produers.FindAsync(producer.ProducerId);
                if (existingProducer != null)
                {
                    existingProducer.Name = producer.Name;
                    existingProducer.Bio = producer.Bio;
                    existingProducer.DateOfBirth = producer.DateOfBirth;
                    existingProducer.Company = producer.Company;
                    existingProducer.Gender = producer.Gender;

                    await context.SaveChangesAsync();
                }
                else
                {
                    throw new NotFoundException("Record to update doesn't exist");
                }
            }
            catch (NotFoundException exception)
            {
                loggerService.LogDebug(exception,"Produer to update doesn't exist into the system");
                throw new NotFoundException(exception.Message);
            }
            catch (Exception exception)
            {
                loggerService.LogDebug(exception, "Failed updating the producer into the database");
                throw new InternalServerException(exception.Message);
            }
            loggerService.LogInformation("Updated producer successfully to the database....");
            return true;
        }

        public async Task<List<Producer>> GetAllProducersAsync()
        {
            List<Producer> producers;
            try
            {
                loggerService.LogInformation("Retrieving producers from the database....");
                producers =  await context.Produers.ToListAsync<Producer>();
            }
            catch (Exception exception)
            {
                loggerService.LogDebug(exception, "Failed retrieving the producers from the system");
                throw new InternalServerException(exception.Message);
            }
            loggerService.LogInformation("Successfully retrieved producers from the database....");
            return producers;   
        }
    }
}
