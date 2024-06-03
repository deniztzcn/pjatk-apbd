using apbd_tutorial08.Application.Services.Abstraction;
using apbd_tutorial08.Application.Services.Implementation;
using apbd_tutorial08.Infrastructure.Repository;

namespace apbd_tutorial08.Application;

public static class ApplicationServicesExtension
{
    public static void RegisterApplicationServices(this IServiceCollection app)
    {
        app.AddScoped<ITripService, TripService>();
        app.AddScoped<IClientService, ClientService>();
    }
}