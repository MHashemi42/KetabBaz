namespace KetabBaz.Infrastructure.Data.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(KetabBazDbContext dbContext)
        : base(dbContext)
    {
    }
}
