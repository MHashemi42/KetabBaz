namespace KetabBaz.Core.Interfaces;

public interface IBookRepository : IRepository<Book>
{
    Task<IEnumerable<Book>> GetBooksForSearchAsync(SearchBookParameters parameters);
    Task<int> GetBooksCountAsync(SearchBookParameters parameters);
    Task AddViewToBook(int bookId, IPAddress ip);
}
