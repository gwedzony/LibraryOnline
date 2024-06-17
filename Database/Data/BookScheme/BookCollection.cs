using System.Collections.ObjectModel;
using Database.DATA.BookScheme;
using Microsoft.VisualBasic;

namespace Database.Data.BookScheme;

public class BookCollection
{
    
    public int BookId { get; set; }
    public Book? Book { get; set; } = null!;
    
    public int CollectionId { get; set; }
    public Collections? Collections { get; set; } = null!;
}