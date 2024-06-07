using System.ComponentModel.DataAnnotations.Schema;
using Database.Data.BookScheme;

namespace Database.DATA.Library;

public class AuthorPage
{
    public int AuthorPageId { get; set; }
    
    [ForeignKey("Author")] 
    public int? AuthorId { get; set; }
    public Author? Author { get; set; }
}