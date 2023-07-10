namespace KetabBaz.Core.Entities;

public class Publisher : EntityBase
{
    public string Title { get; set; }
    public string ImageUrl { get; set; }

    public ICollection<Book> Books { get; set; }
}
