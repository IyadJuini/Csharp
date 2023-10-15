#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsAndDishes.Models;
public  class Dish
{
    [Key]
    public int DishId { get; set; }
    
    [Required]
    public int ChefId { get; set; }


    [Required(ErrorMessage = "Please add a Name to the Dish .")]
    [MinLength(3, ErrorMessage = "Title must be at least 3 .")]
    public string Name { get; set; }

    [Required]
    [Range(1,5, ErrorMessage= "Value must be between 1 and 5 ")]
    public int Tastiness { get; set; }
    [Required]
    public int Calories { get; set; }
    public Chef? MyDish { get; set; }

}