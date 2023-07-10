namespace KetabBaz.Core.Entities;

public class Book : EntityBase
{
    public string OriginalTitle { get; set; }
    public string TranslatedTitle { get; set; }
    public string Description { get; set; }
    public string Isbn { get; set; }
    public int Pages { get; set; }
    public string ImageUrl { get; set; }
    public string Size { get; set; }
    public string Cover { get; set; }
    public DateTime PublishDate { get; set; }
    public int AuthorId { get; set; }
    public int? TranslatorId { get; set; }
    public int PublisherId { get; set; }

    public Author Author { get; set; }
    public Author Translator { get; set; }
    public Publisher Publisher { get; set; }
    public ICollection<Category> Categories { get; set; }
    public ICollection<View> Views { get; set; }
    public ICollection<Tag> Tags { get; set; }
}
