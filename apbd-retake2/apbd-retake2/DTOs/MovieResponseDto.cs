using System.Collections;

namespace apbd_retake2.DTOs;

public class MovieResponseDto
{
    public required int IdMovie { get; set; }
    public required AgeRatingResponseDto AgeRating { get; set; }
    public required string Name { get; set; }
    public required DateTime ReleaseDate { get; set; }
    public required ICollection<ActorResponseDto> Actors { get; set; } = new List<ActorResponseDto>();

}