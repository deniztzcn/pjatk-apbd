using System.ComponentModel.DataAnnotations;

namespace apbd_test_1.Models;

public class TaskType
{
    public int IdTaskType { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
}