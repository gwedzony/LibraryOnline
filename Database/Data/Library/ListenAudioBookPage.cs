using System.ComponentModel.DataAnnotations;
using Database.DATA.BookScheme;
using Database.DATA.CMS;

namespace Database.DATA.Library;

public class ListenAudioBookPage
{
    [Key]
    public int AudioPageId{ get; set; }
        
    [Display(Name = "Link do audiobook`a")]
    public string? AudioUrl{ get; set; }
    public int? BookId { get; set; }
    public Book? Book { get; set; }
    
}