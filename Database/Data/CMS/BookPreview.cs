using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.DATA.CMS;

public class BookPreview
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