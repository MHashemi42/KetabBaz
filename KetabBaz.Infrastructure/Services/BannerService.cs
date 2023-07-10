namespace KetabBaz.Infrastructure.Services;

public class BannerService : IBannerService
{
    private readonly IBannerRepository _bannerRepository;
    private readonly IMapper _mapper;

    public BannerService(IBannerRepository bannerRepository,
        IMapper mapper)
    {
        _bannerRepository = bannerRepository;
        _mapper = mapper;
    }

    public async Task<IList<BannerDto>> GetEnableBanners(int count)
    {
        IEnumerable<Banner> banners = await _bannerRepository
            .GetEnableBanners(count);

        return _mapper.Map<IList<BannerDto>>(banners);
    }
}
