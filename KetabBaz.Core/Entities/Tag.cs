namespace KetabBaz.Core.Entities;

public class Tag : EntityBase
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public ICollection<Book> Books { get; set; }
}
