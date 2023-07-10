namespace KetabBaz.Infrastructure.Data.Repositories;

public class AuthorRepository : Repository<Author>, IAuthorRepository
{
    public AuthorRepository(KetabBazDbContext dbContext)
        : base(dbContext)
    {
    }
}
