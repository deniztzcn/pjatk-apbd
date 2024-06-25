using System.ComponentModel.DataAnnotations;

namespace apbd_retake2.Models;

public class AgeRating
{
    [Key]
    public int IdRating { get; set; }
    [MaxLength(30)]
    public string Name { get; set; }
    
    public ICollection<Movie> Movies { get; set; }
}