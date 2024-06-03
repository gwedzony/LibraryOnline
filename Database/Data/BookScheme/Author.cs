using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Database.DATA.BookScheme;
using Database.DATA.CMS;

namespace Database.Data.BookScheme;

public class Author
{
    [Key]
    public int AuthorId{ get; set; }
    
    [Required(ErrorMessage = "Imie autora jest wymagane")]
    [Display(Name = "Imie")]
    public required string Name{ get; set; }
    [Required(ErrorMessage = "Nazwisko autora jest wymagane")]
    [Display(Name= "Nazwisko")]
    public required string Surname{ get; set; }
    
    public string? Description{ get; set; }
    
    [Display(Name ="URL do zdjecia autora")]
    public string? PhotoUrl{ get; set; }

    public ICollection<Book> Books { get; } = new List<Book>();
}