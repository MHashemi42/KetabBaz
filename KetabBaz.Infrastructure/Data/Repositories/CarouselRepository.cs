namespace KetabBaz.Infrastructure.Data.Repositories;

public class CarouselRepository : Repository<Carousel>, ICarouselRepository
{
    public CarouselRepository(KetabBazDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<IEnumerable<Carousel>> GetCarousels(bool isEnable)
    {
        return await _set
            .Where(c => c.IsEnable == isEnable)
            .ToListAsync();
    }
}
