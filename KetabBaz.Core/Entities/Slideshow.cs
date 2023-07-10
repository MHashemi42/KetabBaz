namespace KetabBaz.Core.Entities;

public class Slideshow : EntityBase
{
    public string Title { get; set; }
    public string Query { get; set; }
    public int Order { get; set; }
}
