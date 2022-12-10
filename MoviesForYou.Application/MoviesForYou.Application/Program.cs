using Microsoft.EntityFrameworkCore;
using MoviesForYou.Application.API;
using MoviesForYou.Application.API.Data;
using MoviesForYou.Application.API.Interfaces;
using MoviesForYou.Application.API.Services;

var builder = WebApplication.CreateBuilder(args);



var startup = new Startup(builder.Configuration);
// Add services to the container.

startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Add Middlewares to the request response pipeline
startup.Configure(app, builder.Environment);
