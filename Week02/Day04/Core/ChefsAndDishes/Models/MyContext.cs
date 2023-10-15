#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace ChefsAndDishes.Models;
public class MyContext : DbContext 
{ 
    public MyContext(DbContextOptions options) : base(options) { }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Chef> Chefs { get; set; } // Our new Table
}