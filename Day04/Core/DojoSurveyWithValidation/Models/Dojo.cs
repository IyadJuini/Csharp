#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
namespace DojoSurveyWithValidation.Models;
public enum Loc
{
Tokyo,
Rome,
SanFran,
Venise
}
public enum FavLang
{
English,
Japanesese,
Italian,
Arabe
}
public class Dojo
{
    [Required(ErrorMessage = "Please add a Name 🐱‍🚀🐱‍🚀.")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 .")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please add a Location 🎃🎃.")]
    public Loc Location { get; set; }
    [Required(ErrorMessage = "Please add a Language 👽👽.")]
    public FavLang FavLanguage { get; set; }
    // [Required]
    [Range(1, 20, ErrorMessage = "Please enter a valid comment 👹👹👹 .")]
    public string  Comment { get; set; }

}