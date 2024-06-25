using System.ComponentModel.DataAnnotations;

namespace apbd_retake2.Models;

public class Actor
{
    [Key]
    public int IdActor { get; set; }
    [MaxLength(30)]
    public string Name { get; set; }
    [MaxLength(30)]
    public string Surname { get; set; }
    
    public ICollection<ActorMovie> ActorMovies { get; set; }
}