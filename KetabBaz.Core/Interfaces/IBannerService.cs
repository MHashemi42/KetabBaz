namespace KetabBaz.Core.Interfaces;

public interface IBannerService
{
    Task<IList<BannerDto>> GetEnableBanners(int count);
}
