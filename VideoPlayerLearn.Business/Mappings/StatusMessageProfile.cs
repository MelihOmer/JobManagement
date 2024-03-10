using AutoMapper;
using VideoPlayerLearn.Business.Dtos;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.Business.Mappings
{
    public class StatusMessageProfile: Profile
    {
        public StatusMessageProfile()
        {
            CreateMap<StatusMessage, StatusMessageResultDto>()
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.StatusUser.FirstName + " " + src.StatusUser.LastName))
                .ForMember(dest => dest.UserImagePath, opt => opt.MapFrom(src => src.StatusUser.ImagePath)).ReverseMap();
        }
    }
}
