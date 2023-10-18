#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // New import for ****
namespace WeddingPlanner.Models;

public class Participation
{
    // Participation Id
    [Key]
    public int ParticipationId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int WeddingId { get; set; }



    // Created At
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Updated At
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    //! Navigation Property
    public Wedding? Creator { get; set; }
    public User? User { get; set; }
    // public List<Participation> MyParticipations { get; set; } = new List<Participation>{}; // OTM Users Crafts
    // public List<Order> MyOrders { get; set; } = new List<Order>{}; // OTM Users Orders

}