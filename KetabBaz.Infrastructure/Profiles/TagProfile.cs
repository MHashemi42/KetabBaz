namespace KetabBaz.Infrastructure.Profiles;

public class TagProfile : Profile
{
    public TagProfile()
    {
        CreateMap<Tag, TagDto>();
    }
}
