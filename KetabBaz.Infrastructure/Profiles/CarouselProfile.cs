namespace KetabBaz.Infrastructure.Profiles;

public class CarouselProfile : Profile
{
    public CarouselProfile()
    {
        CreateMap<Carousel, CarouselDto>();
    }
}
