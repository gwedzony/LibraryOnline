using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Data.BookScheme;
using Database.DATA.Library;


namespace Database.DATA.CMS;
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
    
    /// <summary>
    /// Foreign Keys
    /// </summary>
    
    [ForeignKey("Author")]
    public int IdAuthor { get; set; }
    public Author? Author { get; set; }
    
    [ForeignKey("BookType")]
    public int IdBookType{ get; set; }
    public BookType? BookType{ get; set; }
    
    [ForeignKey("Genre")]
    public int IdGenre { get; set; }
    public Genre? Genre { get; set; }

    public ICollection<Collections> Collections { get; } = new List<Collections>();
    
    public BookPreview? BookPreview { get; set; }
    public BookPage? BookPage { get; set; }
    public ListenAudioBookPage? ListenAudioBookPage { get; set; }
    public ReadOnlineBook? ReadOnlineBook{ get; set; }
    
}