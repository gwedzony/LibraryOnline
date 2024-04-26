using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
   
   [ForeignKey("Books")]
   public int? BookId { get; set; }

   public Book? Book { get; set; } = null!; 
}