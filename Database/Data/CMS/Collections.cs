using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Data.BookScheme;


namespace Database.DATA.CMS;

public class Collections
{
    [Key]
    public int CollectionId { get; set; }
    
    [Required(ErrorMessage = "Musisz podać nazwę dla kolekcji")]
    [Display(Name = "Nazwa kolekcji (np. Nowoczesne, starożytne)")]
    public required string CollectionName { get; set; }
    
    public ICollection<Book> Books { get; } = new List<Book>();
  
    
    
}