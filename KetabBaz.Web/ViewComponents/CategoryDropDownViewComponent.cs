namespace KetabBaz.Web.ViewComponents;

public class CategoryDropDownViewComponent : ViewComponent
{
    private readonly ICategoryService _categoryService;

    public CategoryDropDownViewComponent(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        IEnumerable<CategoryDto> categories =
            await _categoryService.GetCategoriesAsync();

        return View(categories);
    }
}
