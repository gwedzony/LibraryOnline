using System.ComponentModel.DataAnnotations;

namespace Database.DATA.CMS;

public class HomePageDictionaries
{
    [Display(Name = "Tekst wyświetlany w header strony")]
    public string LogoTitle{ get; set; }
    
   [Display(Name = "Tekst nad malymi kartami")]
   public string PositionFirstTopText{ get; set; }
    
   [Display(Name = "Tekst nad duzymi kartami")]
   public string PositionSecondTopText{ get; set; }
   
   [Display(Name = "Tekst w stopce")]
   public string FooterText{ get; set; }
   
   [Display(Name = "Nazwa linku w kartach w pozycji 1")]
   public string linkTextInNewsCard { get; set; }
   
   [Display(Name = "Ikona ksiazki")]
   public string bookIconInCollectionCard { get; set; }
   
   [Display(Name = "Ikona audiobooka")]
   public string audiobookIconInCollectionCard { get; set; }

   
}