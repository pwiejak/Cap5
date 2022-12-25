using CapFive.Web;
using CapFive.Web.Services;
using CapFive.Web.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7038/") });

// Services
builder.Services.AddScoped<IPlayersService, PlayersService>();
builder.Services.AddScoped<ITournamentsService, TournamentsService>();
builder.Services.AddLocalization();

await builder.Build().RunAsync();
