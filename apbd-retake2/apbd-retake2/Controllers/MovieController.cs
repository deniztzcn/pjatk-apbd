using apbd_retake2.DTOs.Requests;
using apbd_retake2.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_retake2.Controllers;

[ApiController]
[Route("api/movies")]
public class MovieController: ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMoviesWithDetails([FromQuery] string? ageRating, [FromQuery] DateTime? releaseDate)
    {
        var moviesWithDetails = await _movieService.GetMoviesWithDetails(ageRating, releaseDate);
        return Ok(moviesWithDetails);
    }

    [HttpPost]
    [Route("api/movies/{movieId}/actors/{actorId}")]
    public async Task<IActionResult> AssignActorToMovie(int movieId, int actorId, [FromBody] AssignActorRequest request)
    {
        var dto = new AssignActorDto
        {
            actorId = actorId,
            movieId = movieId,
            ActorName = request.ActorName,
            ActorSurname = request.ActorSurname,
            CharacterName = request.CharacterName
        };
        
        var id = await _movieService.AssignActorToMovie(dto);
        return Created($"api/movies/{{id}}/actors/{actorId}",new{IdActorMovie = id});
    }

    public class AssignActorRequest
    {
        public required string ActorName { get; set; }
        public required string ActorSurname { get; set; }
        public required string CharacterName { get; set; }
    }
    
}