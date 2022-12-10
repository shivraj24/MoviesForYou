using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MoviesForYou.Application.API.Data;
using MoviesForYou.Application.API.Interfaces;
using MoviesForYou.Application.API.Services;

namespace MoviesForYou.Application.API
{
    public class Startup
    {
        public IConfiguration configuration { get; set; }
        public Startup(IConfiguration _configuration)
        {
            configuration =  _configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<MoviesDataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddTransient<IMovieServices, MovieServices>();
            services.AddTransient<IActorServices, ActorServices>();
            services.AddTransient<IProducerServices, ProducerServices>();
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
    }
}
