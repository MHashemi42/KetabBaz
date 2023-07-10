namespace KetabBaz.Infrastructure.Services;

public class CarouselService : ICarouselService
{
    private readonly ICarouselRepository _carouselRepository;
    private readonly IMapper _mapper;

    public CarouselService(ICarouselRepository carouselRepository,
        IMapper mapper)
    {
        _carouselRepository = carouselRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CarouselDto>> GetCarousels(bool isEnable)
    {
        IEnumerable<Carousel> carousels = await _carouselRepository
            .GetCarousels(isEnable);

        return _mapper.Map<IEnumerable<CarouselDto>>(carousels);
    }
}
