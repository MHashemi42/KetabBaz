namespace KetabBaz.Web.Pages;

public class BookModel : PageModel
{
    private readonly IBookService _bookService;

    public BookDto Book { get; set; }
    public BookModel(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<IActionResult> OnGetAsync(int bookId)
    {
        Book = await _bookService.GetBookByIdAsync(bookId);
        if (Book is null)
        {
            return NotFound();
        }

        return Page();
    }
}
