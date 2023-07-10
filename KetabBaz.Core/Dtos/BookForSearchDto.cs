namespace KetabBaz.Core.Dtos;

public class BookForSearchDto
{
    public int Id { get; set; }
    public string TranslatedTitle { get; set; }
    public string AuthorName { get; set; }
    public string TranslatorName { get; set; }
    public string ImageUrl { get; set; }
}
