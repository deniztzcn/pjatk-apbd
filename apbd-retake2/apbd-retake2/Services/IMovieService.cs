using apbd_retake2.DTOs;
using apbd_retake2.DTOs.Requests;
using apbd_retake2.Exceptions;
using apbd_retake2.Models;
using apbd_retake2.Repositories;

namespace apbd_retake2.Services;

public interface IMovieService
{
    Task<IEnumerable<MovieResponseDto>> GetMoviesWithDetails(string? ageRating, DateTime? releaseDate);
    Task<int> AssignActorToMovie(AssignActorDto dto);
}

public class MovieService: IMovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IActorRepository _actorRepository;

    public MovieService(IMovieRepository movieRepository, IActorRepository actorRepository)
    {
        _movieRepository = movieRepository;
        _actorRepository = actorRepository;
    }

    public async Task<IEnumerable<MovieResponseDto>> GetMoviesWithDetails(string? ageRating, DateTime? releaseDate)
    {
        return await _movieRepository.GetMoviesWithDetails(ageRating, releaseDate);
    }

    public async Task<int> AssignActorToMovie(AssignActorDto dto)
    {
        var movie = await _movieRepository.GetMovieAsync(dto.movieId) ?? throw new MovieNotFound(dto.movieId);
        var actor = await _actorRepository.GetActorAsync(dto.actorId) ?? await _actorRepository.AddActor(dto.ActorName,dto.ActorSurname);
        
        var actorMovie = new ActorMovie
        {
            Actor = actor,
            Movie = movie,
            CharacterName = dto.CharacterName
        };

        var isCharNameExistsInMovie = await
            _movieRepository.IsCharacterNameUnique(actorMovie.IdMovie, actorMovie.CharacterName);

        if (isCharNameExistsInMovie)
        {
            throw new CharacterNameAlreadyExistsInTheMovie();
        }
        

        var addedRecord = await _movieRepository.AddActorMovie(actorMovie);
        return addedRecord.IdActorMovie;
    }
}