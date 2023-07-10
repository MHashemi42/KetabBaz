namespace KetabBaz.Core.Interfaces;

public interface ICarouselService
{
    Task<IEnumerable<CarouselDto>> GetCarousels(bool isEnable);
}
