namespace KetabBaz.Web.ViewComponents;

public class CarouselViewComponent : ViewComponent
{
    private readonly ICarouselService _carouselService;

    public CarouselViewComponent(ICarouselService carouselService)
    {
        _carouselService = carouselService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        IEnumerable<CarouselDto> carousels = await _carouselService
            .GetCarousels(isEnable: true);

        CarouselViewModel carouselViewModel = new()
        {
            MainCarousels = carousels.Where(c => c.IsMainCarousel == true),
            SideCarousels = carousels.Where(c => c.IsMainCarousel == false)
        };
        return View(carouselViewModel);
    }
}
