using apbd_retake2.Repositories;

namespace apbd_retake2.Services;

public static class RegisterationService
{
    public static void RegisterServices(this IServiceCollection app)
    {
        app.AddScoped<IMovieService, MovieService>();
    }
    
    public static void RegisterRepositories(this IServiceCollection app)
    {
        app.AddScoped<IMovieRepository, MovieRepository>();
        app.AddScoped<IActorRepository, ActorRepository>(); 
    }
}