using System.ComponentModel.DataAnnotations;
using Database.DATA.BookScheme;
using Database.DATA.CMS;


namespace Database.DATA.Library;

public class ReadOnlineBook
{
    [Key]
    public int ReadOnlineId { get; set; }
    
    public int? BookId { get; set; }
    public Book? Book { get; set; }
    
}