namespace KetabBaz.Infrastructure.Data.Repositories;

public class SlideshowRepository : Repository<Slideshow>, ISlideshowRepository
{
    public SlideshowRepository(KetabBazDbContext dbContext)
        : base(dbContext)
    {

    }

    public async Task<IList<Slideshow>> GetSlideshows(int count)
    {
        return await _set
            .AsNoTracking()
            .OrderBy(s => s.Order)
            .Take(count)
            .ToListAsync();
    }
}
