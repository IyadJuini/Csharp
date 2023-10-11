#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CruDelicious.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }

    [Required(ErrorMessage = "Please add a Name .")]
    [MinLength(3, ErrorMessage = "Name must be at least 3 .")]
    public string Name { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Please add a Chef .")]
    public string Chef { get; set; }

    [Required]
    [Range(1, 5, ErrorMessage = "Tastiness is required.")]
    public int Tastiness { get; set; }

    [Required]
    [Range(1, 5, ErrorMessage = "Calories is required.")]
    public int Calories { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Please add a Description .")]
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}