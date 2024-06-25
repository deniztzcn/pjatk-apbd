namespace apbd_retake2.DTOs.Requests;

public class AssignActorDto
{
    public required int movieId { get; set; }
    public required int actorId { get; set; }
    public required string ActorName { get; set; }
    public required string ActorSurname { get; set; }
    public required string CharacterName { get; set; }
}