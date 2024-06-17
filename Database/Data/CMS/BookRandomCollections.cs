using System.ComponentModel.DataAnnotations;
using Database.DATA.BookScheme;

namespace Database.DATA.CMS;

public class BookRandomCollections
{
    [Key]
    public int Id
    {
        get;
        set;
    }

    public ICollection<Collections> Collections = new List<Collections>();

}