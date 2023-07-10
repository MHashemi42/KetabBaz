namespace KetabBaz.Infrastructure.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookForSearchDto>();
        CreateMap<Book, BookDto>();
    }
}
