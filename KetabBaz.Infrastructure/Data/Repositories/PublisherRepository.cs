namespace KetabBaz.Infrastructure.Data.Repositories;

public class PublisherRepository : Repository<Publisher>, IPublisherRepository
{
    public PublisherRepository(KetabBazDbContext dbContext)
        : base(dbContext)
    {
    }
}
