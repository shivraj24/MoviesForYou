using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MoviesForYou.Application.API;
using MoviesForYou.Application.API.Data;
using MoviesForYou.Application.API.Interfaces;
using MoviesForYou.Application.API.Services;


namespace MoviesForYou.Application.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}