using AutoMapper;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos;

namespace VideoPlayerLearn.Business.Mappings
{
    public class AppUserProfile :Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, AppUserCreateDto>().ReverseMap();
            CreateMap<AppUser,AppUserListDto>().ReverseMap();
            CreateMap<AppUser,AppUserUpdateDto>().ReverseMap();
        }
    }
}
