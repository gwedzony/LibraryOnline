using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Data.BookScheme;
using Database.DATA.CMS;
using Database.DATA.Library;


namespace Database.DATA.BookScheme;
public class Book
{
    [Key] 
    public int BookId { get; set; }
    
    [Required(ErrorMessage = "Musisz podac tyuł ksiązki")]
    [Display(Name = "Tytuł książki")]
    public required string Title{ get; set; }
    
    [Required(ErrorMessage = "Musisz utworzyć opis ksiązki")]
    [Display(Name = "Krótki opis książki")]
    public required string Description{ get; set; }
    
    [Required(ErrorMessage = "Musisz dodać okładkę")]
    [Display(Name = "Okładka książki")]
    public string image { get; set; }
    public long? ReadCount { get; set; }
    

    [ForeignKey("Author")]
    public int IdAuthor { get; set; }
    public Author? Author { get; set; }
  
    
    [ForeignKey("BookType")]
    public int IdBookType{ get; set; }
    public BookType? BookType{ get; set; }
    
    
    [ForeignKey("Genre")]
    public int IdGenre { get; set; }
    public Genre? Genre { get; set; }

    public int? BookNewsCardId { get; set; }
    public BookNewsCard? BookNewsCard { get; set; }

    public ICollection<BookCollection> BookCollections { get; } = [];
    
    public BookPage? BookPage { get; set; }
   
    
}