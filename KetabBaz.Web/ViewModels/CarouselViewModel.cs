namespace KetabBaz.Web.ViewModels;

public class CarouselViewModel
{
    public IEnumerable<CarouselDto> MainCarousels { get; set; }
    public IEnumerable<CarouselDto> SideCarousels { get; set; }
}
