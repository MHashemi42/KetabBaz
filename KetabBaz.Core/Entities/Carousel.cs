namespace KetabBaz.Core.Entities;

public class Carousel : EntityBase
{
    public string ImageUrl { get; set; }
    public string Url { get; set; }
    public bool IsEnable { get; set; }
    public bool IsMainCarousel { get; set; }
}
