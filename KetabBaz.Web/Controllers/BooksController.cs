namespace KetabBaz.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookForSearchDto>>>
        GetBooksForSearch([FromQuery] SearchBookParameters parameters)
    {
        return Ok(await _bookService.GetBooksForSearchAsync(parameters));
    }

    [HttpGet("view/{bookId}")]
    public async Task<IActionResult> AddViewForBook(int bookId)
    {
        IPAddress userIp = HttpContext.Connection.RemoteIpAddress;
        await _bookService.AddViewForBook(bookId, userIp);

        return Ok();
    }
}
