namespace KetabBaz.Infrastructure.Profiles;

public class SlideshowProfile : Profile
{
    public SlideshowProfile()
    {
        CreateMap<Slideshow, SlideshowDto>();
    }
}
