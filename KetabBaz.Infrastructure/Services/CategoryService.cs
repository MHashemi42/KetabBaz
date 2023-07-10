namespace KetabBaz.Infrastructure.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
    {
        IEnumerable<Category> categories = await _categoryRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }
}
