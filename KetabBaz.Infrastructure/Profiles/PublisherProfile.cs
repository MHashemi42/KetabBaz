namespace KetabBaz.Infrastructure.Profiles;

public class PublisherProfile : Profile
{
    public PublisherProfile()
    {
        CreateMap<Publisher, PublisherDto>();
    }
}
