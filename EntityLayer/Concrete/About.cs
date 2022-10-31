using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
  public class About
  {
    [Key]
    public int AboutId { get; set; }
    public string AboutDetail1 { get; set; }
    public string AboutDetail2 { get; set; }
    public string AboutDetailIMage1 { get; set; }
    public string AboutDetailIMage2 { get; set; }
    public string AboutMapLocation { get; set; }
    public bool AboutStatus { get; set; }
  }
}
