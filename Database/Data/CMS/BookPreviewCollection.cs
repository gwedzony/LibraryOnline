using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.DATA.BookScheme;

namespace Database.DATA.CMS;

public class BookPreviewCollection
{
    [Key]
    public int PreviewId
    {
        get;
        set;
    }
    [Display(Name = "Link do zdjecia okładki")]
    public string? SmallCoverImg{ get; set; }
   
    [Display(Name = "Link do książki")]
    public string? PdfUrl{ get; set; }
    
    [Display(Name = "Link do audiobooka")]
    public string? AudioUrl { get; set; }
    
    [ForeignKey("Books")]
    public int? BookId { get; set; }
    public Book? Book { get; set; }

}