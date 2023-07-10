namespace KetabBaz.Web.Pages;

public class IndexModel : PageModel
{
    private readonly IBannerService _bannerService;
    private readonly ISlideshowService _slideshowService;

    public IList<BannerDto> Banners { get; set; }
    public IList<SlideshowDto> Slideshows { get; set; }
    public IndexModel(IBannerService bannerService, ISlideshowService slideshowService)
    {
        _bannerService = bannerService;
        _slideshowService = slideshowService;
    }

    public async Task OnGetAsync()
    {
        Banners = await _bannerService.GetEnableBanners(count: 12);
        Slideshows = await _slideshowService.GetSlideshows(count: 3);
    }
}
