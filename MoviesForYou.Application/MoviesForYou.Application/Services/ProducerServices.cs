using Microsoft.EntityFrameworkCore;
using MoviesForYou.Application.API.Data;
using MoviesForYou.Application.API.ExceptionHandler;
using MoviesForYou.Application.API.Interfaces;
using MoviesForYou.Application.API.Models;

namespace MoviesForYou.Application.API.Services
{
    public class ProducerServices : IProducerServices
    {
        private readonly MoviesDataContext context;
        private readonly IValidationService validationService;
        public ProducerServices(MoviesDataContext _context,IValidationService _validationService)
        {
            this.context = _context;
            this.validationService = _validationService;
        }
        public async Task<bool> AddProducerAsync(Producer producer)
        {
            if(!validationService.isValidProducer(producer))
            {
                throw new BadRequestException("Invalid Request Paramters");
            }
            try
            {
                await context.Produers.AddAsync(producer);
                await context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new InternalServerException(exception.Message);
            }
            return true;
        }

        public async Task<bool> UpdateProducerAsync(Producer producer)
        {
            if(producer.ProducerId <= 0  && !validationService.isValidProducer(producer))
            {
                throw new BadRequestException("Invalid Request parameters");
            }
            try
            {
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
                throw new NotFoundException(exception.Message);
            }
            catch (Exception exception)
            {
                throw new InternalServerException(exception.Message);
            }
            return true;
        }

        public async Task<List<Producer>> GetAllProducersAsync()
        {
            try
            {
                return await context.Produers.ToListAsync<Producer>();
            }
            catch (Exception exception)
            {
                throw new InternalServerException(exception.Message);
            }
        }
    }
}
