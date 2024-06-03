using System.ComponentModel.DataAnnotations;
using Database.DATA.BookScheme;
using Database.DATA.CMS;

namespace Database.Data.BookScheme;

public class BookType
{
    [Key]
    public int BookTypeId{ get; set; }
    [Required(ErrorMessage = "Podanie nazwy typu jest wymagane")]
    [Display(Name = "Rodzaj książki")]
    public required string BookTypeName { get; set; }
    
    public ICollection<Book> Book { get; } = new List<Book>();
}