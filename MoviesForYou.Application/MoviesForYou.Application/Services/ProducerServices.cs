using Microsoft.EntityFrameworkCore;
using MoviesForYou.Application.API.Data;
using MoviesForYou.Application.API.Interfaces;
using MoviesForYou.Application.API.Models;

namespace MoviesForYou.Application.API.Services
{
    public class ProducerServices : IProducerServices
    {
        private readonly MoviesDataContext context;
        public ProducerServices(MoviesDataContext _context)
        {
            context = _context;
        }
        public async Task<bool> AddProducerAsync(Producer producer)
        {
            try
            {
                await context.Produers.AddAsync(producer);
                await context.SaveChangesAsync();
            }
            catch (Exception) {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateProducerAsync(Producer producer)
        {
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
                    return false;
                }
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Producer>> GetAllProducersAsync()
        {
            try
            {
                return await context.Produers.ToListAsync<Producer>();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
