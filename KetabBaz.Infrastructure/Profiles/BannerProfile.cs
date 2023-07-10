namespace KetabBaz.Infrastructure.Profiles;

public class BannerProfile : Profile
{
    public BannerProfile()
    {
        CreateMap<Banner, BannerDto>();
    }
}
