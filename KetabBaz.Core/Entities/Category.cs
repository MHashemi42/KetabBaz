namespace KetabBaz.Core.Entities;

public class Category : EntityBase
{
    public string Title { get; set; }

    public ICollection<Book> Books { get; set; }
}
