using System.ComponentModel.DataAnnotations;

namespace Restaurant.Website.Models;

public class Newsletter
{
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    public DateTime Created { get; set; }
}