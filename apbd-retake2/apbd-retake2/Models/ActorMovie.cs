namespace apbd_retake2.Models;

public class ActorMovie
{
    public int IdActorMovie { get; set; }
    public int IdMovie { get; set; }
    public int IdActor { get; set; }
    public Actor Actor { get; set; }
    public Movie Movie { get; set; }
    public string CharacterName { get; set; }
}