# Day 8

## Objectives
* Create a simple login and registration website


## Steps

### Step 1: Create MVC Project
````
    dotnet new mvc --no-https -o YourProjectName
````

### Step 2: Install packages

```
    dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.1
    dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.3
```

### Step 3: Make your model

```
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace YourProjectName.Models;
public class Item
{
    [Key]
    public int ItemId { get; set; }
    public string Name { get; set; } 
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
```


### Step 4: Set up your MyContext file


Create a MyContext.cs file in your Models folder and add the following code (edit it to match your needs):

```
#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace YourProjectName.Models;
public class MyContext : DbContext 
{ 
    public MyContext(DbContextOptions options) : base(options) { }
    public DbSet<Item> Items { get; set; } 
}
```

### Step 5: Setting up our connection string
In appsettings.json paste the database connection string.
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
    "ConnectionStrings":
    {
        "DefaultConnection": "Server=localhost;port=3306;userid=root;password=root;database=mydbnamedb;"
    }
}
```

### Step 6: Setting up our connection in Program.cs
#### SetUp Context : 

Now that everything is in place, it's time to hook things up in your Program.cs.
```
// Additional using statements around here
using Microsoft.EntityFrameworkCore;
using ProjectName.Models;

// This should look familiar
var builder = WebApplication.CreateBuilder(args)

//  Creates the db connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Adds database connection - must be before app.Build();
builder.Services.AddDbContext<MyContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
```
Now that that is done, there is one more task to do within our code.
#### SetUp Session : 
```
builder.Services.AddHttpContextAccessor();  // AddHttpContextAccessor gives our views direct access to session so that session data doesn't need to be repeatedly passed into the ViewBag.
builder.Services.AddSession();  // add this line before calling the builder.Build() method
app.UseSession();  // add this line before calling the app.MapControllerRoute() method
``` 

## Step 7: Bringing our database to our controller for use
The final step requires us to establish a connection in our controller that will allow us to grab anything we need from the database. 

Your code will look something like this:
```
using System.Diagnostics
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using YourProjectName.Models;
namespace YourProjectName.Controllers;
    
public class HomeController : Controller
{
    private MyContext _context;
    // This is already in your controller
    private readonly ILogger<HomeController> _logger;
     
    // here we can "inject" our context service into the constructor
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        // This becomes the name we use to reference our database
        _context = context;
    }
     
    [HttpGet("")]
    public IActionResult Index()
    {
        // Note this will not work yet until we migrate our tables and have actual data in the database
        List<Item> AllItems = _context.Items.OrderBy(a => a.Name).ToList();
            
        return View();
    }
 }
```

## Step 8: Migrating our tables

First you must stage the changes:
```
    dotnet ef migrations add YourMigrationName
```

Finally we push the changes to our database:
```
    dotnet ef database update
```

## Step 9 Accessing Session in your Views

To access session directly in our views, we will need to add this using statement to our _ViewImports.cshtml file:
```
@using Microsoft.AspNetCore.Http
```
