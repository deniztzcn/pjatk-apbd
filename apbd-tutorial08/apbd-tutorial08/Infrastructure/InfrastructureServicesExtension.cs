using apbd_tutorial08.Application.Repository;
using apbd_tutorial08.Context;
using apbd_tutorial08.Infrastructure.Repository;

namespace apbd_tutorial08.Infrastructure;

public static class InfrastructureServicesExtension
{
    public static void RegisterInfrastructureServices(this IServiceCollection app)
    {
        app.AddScoped<ITripRepository, TripRepository>();
        app.AddDbContext<Apbd08Context>();
    }
}