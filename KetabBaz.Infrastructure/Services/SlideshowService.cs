namespace KetabBaz.Infrastructure.Services;

public class SlideshowService : ISlideshowService
{
    private readonly ISlideshowRepository _slideshowRepository;
    private readonly IMapper _mapper;

    public SlideshowService(ISlideshowRepository slideshowRepository,
        IMapper mapper)
    {
        _slideshowRepository = slideshowRepository;
        _mapper = mapper;
    }

    public async Task<IList<SlideshowDto>> GetSlideshows(int count)
    {
        IEnumerable<Slideshow> slideshows = await _slideshowRepository
            .GetSlideshows(count);

        return _mapper.Map<IList<SlideshowDto>>(slideshows);
    }
}
