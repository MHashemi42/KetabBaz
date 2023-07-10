namespace KetabBaz.Core.Interfaces;

public interface IBookService
{
    Task<IEnumerable<BookForSearchDto>> GetBooksForSearchAsync(SearchBookParameters parameters);
    Task<int> GetBooksTotalPagesAsync(SearchBookParameters parameters);
    Task<BookDto> GetBookByIdAsync(int bookId);
    Task AddViewForBook(int bookId, IPAddress ip);
}
