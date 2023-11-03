#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace BeltExam.Models;

public class Post {
    [Key]
    public int PostId {get;set;}

    [Required]
    public int UserId { get; set; }
    public User? Poster { get; set; } // OTM Users Posts

    [Required(ErrorMessage ="Please Enter Image Url.")]
    [DataType(dataType:DataType.Url,ErrorMessage ="Please enter a valid url.")]
    [Display(Name = "Image (URL format please) ")]
    public string ImageUrl { get; set; }


    [Required(ErrorMessage ="Please Enter Post Title.")]
    public string Title { get; set; }


    [Required(ErrorMessage ="Please Enter Post Medium.")]
    public string Medium { get; set; }


    [Required]
    [Display(Name = "For sale ?")]
    public bool ForSale { get; set; }


        // Created At
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Updated At
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //! Navigation Property
    public List<Like> PostLikes { get; set; } = new List<Like>(); // OTM Posts Likes
}