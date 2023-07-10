namespace KetabBaz.Infrastructure.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository,
        IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task AddViewForBook(int bookId, IPAddress ip)
    {
        await _bookRepository.AddViewToBook(bookId, ip);
    }

    public async Task<int> GetBooksTotalPagesAsync(SearchBookParameters parameters)
    {
        int count = await _bookRepository.GetBooksCountAsync(parameters);
        return (int)Math.Ceiling((decimal)count / parameters.PageSize);
    }

    public async Task<IEnumerable<BookForSearchDto>> GetBooksForSearchAsync(
        SearchBookParameters parameters)
    {
        IEnumerable<Book> bookEntities =
            await _bookRepository.GetBooksForSearchAsync(parameters);

        return _mapper.Map<IEnumerable<BookForSearchDto>>(bookEntities);
    }

    public async Task<BookDto> GetBookByIdAsync(int bookId)
    {
        Book book = await _bookRepository.GetByIdAsync(bookId);

        return _mapper.Map<BookDto>(book);
    }
}
