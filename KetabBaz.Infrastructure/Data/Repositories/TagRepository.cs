namespace KetabBaz.Infrastructure.Data.Repositories;

public class TagRepository : Repository<Tag>, ITagRepository
{
    public TagRepository(KetabBazDbContext dbContext)
        : base(dbContext)
    {
    }
}
