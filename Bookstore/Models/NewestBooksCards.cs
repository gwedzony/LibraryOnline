namespace Bookstore.Models;

public class NewestBooksCards
{
    
    public int Id
    {
        get;
        set;
    }
  
   
    public string BookUrl{ get; set; }
    public string BookImage{ get; set; }
    public string BookTitle{ get; set; }
    public string BookAuthor{ get; set; }
    public string BookDescription{ get; set; }

    public DateTime AddDateTime { get; set; }



}