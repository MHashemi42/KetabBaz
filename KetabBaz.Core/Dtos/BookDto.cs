namespace KetabBaz.Core.Dtos;

public class BookDto
{
    public string TranslatedTitle { get; set; }
    public string ImageUrl { get; set; }
    public string AuthorName { get; set; }
    public string TranslatorName { get; set; }
    public string PublisherTitle { get; set; }
    public string Description { get; set; }
    public string Isbn { get; set; }
    public IEnumerable<CategoryDto> Categories { get; set; }
    public IEnumerable<TagDto> Tags { get; set; }
}
