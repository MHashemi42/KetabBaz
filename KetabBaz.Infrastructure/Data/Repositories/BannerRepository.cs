namespace KetabBaz.Infrastructure.Data.Repositories;

public class BannerRepository : Repository<Banner>, IBannerRepository
{
    public BannerRepository(KetabBazDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<IEnumerable<Banner>> GetEnableBanners(int count)
    {
        return await _set
            .AsNoTracking()
            .Where(b => b.IsEnable)
            .OrderBy(b => b.Order)
            .Take(count)
            .ToListAsync();
    }
}
