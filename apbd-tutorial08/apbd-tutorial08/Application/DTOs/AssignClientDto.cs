namespace apbd_tutorial08.Application.DTOs;

public class AssignClientDto
{
    public required string FirstName { get; set; } = string.Empty;

    public required string LastName { get; set; } = string.Empty;

    public required string Email { get; set; } = string.Empty;

    public required string Telephone { get; set; } = string.Empty;

    public required string Pesel { get; set; } = string.Empty;
    public int IdTrip { get; set; }
    public required string TripName { get; set; }
    public DateTime PaymentDate { get;  set; }
    
}