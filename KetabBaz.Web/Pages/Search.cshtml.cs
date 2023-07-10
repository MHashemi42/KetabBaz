using KetabBaz.Core.Enums;

namespace KetabBaz.Web.Pages;

public class SearchModel : PageModel
{
    private readonly IBookService _bookService;
    private readonly ICategoryService _categoryService;
    private readonly IPublisherService _publisherService;

    [BindProperty(SupportsGet = true)]
    public SearchBookParameters Search { get; set; }
    public IEnumerable<BookForSearchDto> Books { get; set; }
    public IEnumerable<CategoryDto> Categories { get; set; }
    public IEnumerable<PublisherDto> Publishers { get; set; }
    public int TotalPages { get; set; }

    public SearchModel(IBookService bookService, ICategoryService categoryService,
        IPublisherService publisherService)
    {
        _bookService = bookService;
        _categoryService = categoryService;
        _publisherService = publisherService;
    }

    public async Task OnGetAsync()
    {
        Books = await _bookService.GetBooksForSearchAsync(Search);
        TotalPages = await _bookService.GetBooksTotalPagesAsync(Search);
        Categories = await _categoryService.GetCategoriesAsync();
        Publishers = await _publisherService.GetPublishersAsync();
    }
}
