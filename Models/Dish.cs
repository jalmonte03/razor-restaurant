using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Website.Models;

public class Dish 
{
    public int Id { get; set; }

    [Required]
    [StringLength(40)]
    public string? Name { get; set; }

    public decimal Price { get; set; } = 0m;

    [Column(TypeName = "ntext")]
    public string? Ingredients { get; set; }

    public int Calories { get; set; }

    public string? Image { get; set; }
}