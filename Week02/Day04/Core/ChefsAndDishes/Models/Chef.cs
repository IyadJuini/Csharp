#pragma warning disable CS8618
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // New import for **
namespace ChefsAndDishes.Models;


public class PastDate : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if ((DateTime)value > DateTime.Now)
            return new ValidationResult("Date must be in the past");
        else if ((DateTime.Now.Subtract((DateTime)value)).TotalDays / 365 < 18)
            return new ValidationResult("Chef must be at least 18");
        return ValidationResult.Success;
    }
}


public  class Chef
{
    [Key]
    public int ChefId { get; set; }


    [Required(ErrorMessage = "Please add the First Name of the cook .")]
    [MinLength(3, ErrorMessage = "Name must be at least 3 .")]
    public string FirstName { get; set; }
    [Required]
    [MinLength(3, ErrorMessage = "Please enter a valid Lastname .")]
    public string LastName { get; set; }


    [Required]
    [PastDate]
    [Display(Name = "Date of Birth")]
    public DateTime DateOfBirth { get; set; }
            public int Age() 
        {
            TimeSpan interval = DateTime.Now.Subtract(this.DateOfBirth);
            int currentage = (int) Math.Floor(interval.TotalDays / 365);
            return currentage;
        } 



    public List<Dish> MyDishes { get; set; } = new List<Dish>{};

}