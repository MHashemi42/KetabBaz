namespace KetabBaz.Infrastructure.Data.Repositories;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(KetabBazDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task AddViewToBook(int bookId, IPAddress ip)
    {
        Book book = await _set
            .Include(b => b.Views.Where(v => v.IP == ip && v.DateCreated.AddDays(7) > DateTimeOffset.UtcNow))
            .SingleOrDefaultAsync(b => b.Id == bookId);

        if (book is null || book.Views.Any())
        {
            return;
        }

        book.Views.Add(new View { IP = ip, DateCreated = DateTimeOffset.UtcNow });
        await _dbContext.SaveChangesAsync();
    }

    public override async Task<Book> GetByIdAsync(int id)
    {
        return await _set.AsNoTracking()
                        .Include(b => b.Author)
                        .Include(b => b.Translator)
                        .Include(b => b.Publisher)
                        .Include(b => b.Categories)
                        .Include(b => b.Tags)
                        .AsSplitQuery()
                        .SingleOrDefaultAsync(b => b.Id == id);
    }
    public async Task<int> GetBooksCountAsync(SearchBookParameters parameters)
    {
        IQueryable<Book> books = QueryBooksForSearch(parameters);

        return await books.CountAsync();
    }

    public async Task<IEnumerable<Book>> GetBooksForSearchAsync(SearchBookParameters parameters)
    {
        IQueryable<Book> books = QueryBooksForSearch(parameters);

        return await books.Select(b => new Book
        {
            Id = b.Id,
            TranslatedTitle = b.TranslatedTitle,
            Author = b.Author,
            Translator = b.Translator,
            ImageUrl = b.ImageUrl
        })
          .Skip((parameters.PageNumber - 1) * parameters.PageSize)
          .Take(parameters.PageSize)
          .ToListAsync();
    }

    private IQueryable<Book> QueryBooksForSearch(SearchBookParameters parameters)
    {
        IQueryable<Book> books = _set.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(parameters.Query))
        {
            books = books.Where(b => b.OriginalTitle.Contains(parameters.Query) ||
                        b.TranslatedTitle.Contains(parameters.Query) ||
                        b.Author.Name.Contains(parameters.Query) ||
                        b.Translator.Name.Contains(parameters.Query));
        }

        if (!string.IsNullOrWhiteSpace(parameters.Category))
        {
            books = books.Where(b => b.Categories.Any(c => c.Title == parameters.Category));
        }

        if (!string.IsNullOrWhiteSpace(parameters.Publisher))
        {
            books = books.Where(b => b.Publisher.Title == parameters.Publisher);
        }

        books = parameters.SortBy switch
        {
            SortBookType.ByLatest => books.OrderByDescending(b => b.PublishDate),
            SortBookType.ByMostVisited or _ => books.OrderByDescending(b => b.Views.Count)
        };

        return books;
    }
}
