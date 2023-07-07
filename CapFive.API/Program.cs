using CapFive.API.Services;
using CapFive.Data;
using CapFive.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<CapFiveDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CapFiveConnection"))
);

// Repositories
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<IMatchupRepository, MatchupRepository>();

// Services
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<ITournamentService, TournamentService>();
builder.Services.AddScoped<IMatchupService, MatchupService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(policy =>
{
    var allowedOrigins = builder.Configuration.GetValue<string>("AllowedOrigins").Split(',');
    policy.WithOrigins(allowedOrigins)
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType);
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
