using System.ComponentModel.DataAnnotations;

namespace apbd_tutorial06.Models;

public class WarehouseDTO
{
    [Required]
    public int IdProduct { get; set; }
    [Required]
    public int IdWarehouse { get; set; }
    [Required]
    public int Amount { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    
}