using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd_retake2.Models;

public class Movie
{
    [Key]
    public int IdMovie { get; set; }
    [ForeignKey(nameof(AgeRating))]
    public int IdRating { get; set; }
    public AgeRating AgeRating { get; set; }
    [MaxLength(30)]
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    
    public ICollection<ActorMovie> ActorMovies { get; set; }
}