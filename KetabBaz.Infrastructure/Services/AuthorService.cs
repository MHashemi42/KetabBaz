namespace KetabBaz.Infrastructure.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public AuthorService(IAuthorRepository authorRepository,
        IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public async Task<AuthorDto> GetAuthorAsync(int authorId)
    {
        Author authorEntity = await _authorRepository.GetByIdAsync(authorId);
        if (authorEntity is null)
        {
            throw new AuthorNotFoundException();
        }

        return _mapper.Map<AuthorDto>(authorEntity);
    }
}
