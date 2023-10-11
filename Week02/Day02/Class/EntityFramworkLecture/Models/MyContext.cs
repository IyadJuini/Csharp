#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace EntityFramworkLecture.Models;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) { }
    //Add  All Tables Here
    //-access modifier  type DbSet<Model> table name getter setter
    public DbSet<Song> Songs { get; set; }
}