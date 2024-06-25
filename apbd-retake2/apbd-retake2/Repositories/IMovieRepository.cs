using apbd_retake.Data;
using apbd_retake2.DTOs;
using apbd_retake2.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_retake2.Repositories;

public interface IMovieRepository
{
    Task<IEnumerable<MovieResponseDto>> GetMoviesWithDetails(string? ageRating, DateTime? releaseDate);
    Task<Movie?> GetMovieAsync(int movieId);
    Task<ActorMovie> AddActorMovie(ActorMovie actorMovie);
    Task<bool> IsCharacterNameUnique(int movieId, string characterName);
}

public class MovieRepository: IMovieRepository
{
    private readonly AppDbContext _dbContext;

    public MovieRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<MovieResponseDto>> GetMoviesWithDetails(string? ageRating, DateTime? releaseDate)
    {
        var query = _dbContext.Movies
            .Include(m => m.AgeRating)
            .Include(m => m.ActorMovies)
            .ThenInclude(am => am.Actor).AsQueryable();

        if (!string.IsNullOrWhiteSpace(ageRating))
        {
            query = query.Where(x => x.AgeRating.Name == ageRating);
        }

        if (releaseDate.HasValue)
        {
            query = query.Where(x => x.ReleaseDate == releaseDate);
        }

        var queryResult = await query.OrderByDescending(x => x.ReleaseDate).ToListAsync();

        var moviesWithDetails = queryResult.Select(x => new MovieResponseDto
        {
            IdMovie = x.IdMovie,
            Name = x.Name,
            ReleaseDate = x.ReleaseDate,
            AgeRating = new AgeRatingResponseDto
            {
                IdRating = x.IdRating,
                Name = x.AgeRating.Name,
            },
            Actors = x.ActorMovies.Select(am => new ActorResponseDto
            {
                IdActor = am.Actor.IdActor,
                Name = am.Actor.Name,
                Surname = am.Actor.Surname,
                CharacterName = am.CharacterName
            }).ToList()
        }).ToList();

        return moviesWithDetails;
    }

    public async Task<Movie?> GetMovieAsync(int movieId)
    {
        return await _dbContext.Movies.FindAsync(movieId);
    }

    public async Task<ActorMovie> AddActorMovie(ActorMovie actorMovie)
    {
         _dbContext.ActorMovies.Add(actorMovie);
        
        await _dbContext.SaveChangesAsync();
        return actorMovie;
    }

    public async Task<bool> IsCharacterNameUnique(int movieId, string characterName)
    {
        var query = await _dbContext.ActorMovies.Where(x => x.IdMovie == movieId)
            .AnyAsync(x => x.CharacterName == characterName);
        return query;
    }
}