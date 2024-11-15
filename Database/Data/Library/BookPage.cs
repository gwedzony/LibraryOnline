using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.DATA.BookScheme;
using Database.DATA.CMS;

namespace Database.DATA.Library;

public class BookPage
{
   [Key]
   public int BookPageId { get; set; }
   
   [Display(Name = "Link do zdjecia okładki")]
   public string? BigCoverImg{ get; set; }
   
   [Display(Name = "Link do książki")]
   public string? PdfUrl{ get; set; }
   
   [Display(Name = "Link do Audiobook`a")]
   public string? AudioUrl{ get; set; }
   
   [Required(ErrorMessage = "Dodaj długi opis książki")]
   [Display(Name = "Opis książki")]
   public string LongDescription { get; set; }
   
   [ForeignKey("Books")]
   public int? BookId { get; set; }

   public Book? Book { get; set; } = null!; 
}