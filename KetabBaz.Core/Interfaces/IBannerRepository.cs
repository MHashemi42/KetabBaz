namespace KetabBaz.Core.Interfaces;

public interface IBannerRepository : IRepository<Banner>
{
    Task<IEnumerable<Banner>> GetEnableBanners(int count);
}
