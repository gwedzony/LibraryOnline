using System.ComponentModel.DataAnnotations;
using Database.DATA.CMS;

namespace Database.Data.BookScheme;

public class Genre
{
    [Key]
    public int GenreId{ get; set; }
    
    [Required(ErrorMessage = "Nazwa gatunku jest wymagana")]
    [Display(Name = "Gatunek (np. Horror, Thriller)")]
    public required string Name{ get; set; }

    public ICollection<Book> Book { get; } = new List<Book>();

}