namespace KetabBaz.Infrastructure.Services;

public class PublisherService : IPublisherService
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IMapper _mapper;

    public PublisherService(IPublisherRepository publisherRepository,
        IMapper mapper)
    {
        _publisherRepository = publisherRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PublisherDto>> GetPublishersAsync()
    {
        IEnumerable<Publisher> publishers = await _publisherRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<PublisherDto>>(publishers);
    }
}
