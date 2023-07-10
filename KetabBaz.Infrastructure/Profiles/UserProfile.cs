using KetabBaz.Infrastructure.Data.Identity;
using KetabBaz.Infrastructure.Models;

namespace KetabBaz.Infrastructure.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserRegistration, User>();
    }
}
