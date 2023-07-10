namespace KetabBaz.Core.Interfaces;

public interface ICarouselRepository : IRepository<Carousel>
{
    Task<IEnumerable<Carousel>> GetCarousels(bool isEnable);
}
