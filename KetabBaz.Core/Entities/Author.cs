namespace KetabBaz.Core.Entities;

public class Author : EntityBase
{
    public string Name { get; set; }
    public string Bio { get; set; }
    public string ImageUrl { get; set; }

    public ICollection<Book> TranslatedBooks { get; set; }
    public ICollection<Book> WrittenBooks { get; set; }
}
