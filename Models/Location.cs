using System.ComponentModel.DataAnnotations;

namespace Restaurant.Website.Models;

public class Location 
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(80)]
    public string? Name { get; set; }

    [Required]
    [StringLength(10)]
    public string? Phone { get; set; }

    [Required]
    [StringLength(150)]
    public string? StreetAddress { get; set; }

    [Required]
    [MinLength(3)]
    [StringLength(80)]
    public string? City { get; set; }

    [Required]
    public string? State { get; set; }

    [Required]
    [MinLength(5)]
    [StringLength(10)]
    public string? ZipCode { get; set; }

    public string? LocationImage { get; set; }
}