using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.DATA.BookScheme;

namespace Database.DATA.CMS;

public class BookNewsCard
{
    [Key]
    public int BookNewsCardId { get; set; }
    
    [Display(Name = "Link do zdjecia okładki")]
    public string? SmallCoverImg{ get; set; }
   
    [Display(Name = "Link do strony książki")]
    public string? BookLink{ get; set; }

    public DateTime WhenCreated { get; set; } = DateTime.Now;
    
    [ForeignKey("Books")]
    public int? BookId { get; set; }
    public Book? Book { get; set; }

}