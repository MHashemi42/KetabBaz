namespace KetabBaz.Core.Entities;

public class Banner : EntityBase
{
    public string ImageUrl { get; set; }
    public string Url { get; set; }
    public bool IsEnable { get; set; }
    public int Order { get; set; }
}
