using AutoMapper;
using VideoPlayerLearn.Business.Dtos;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.Business.Mappings
{
    public class ClientNotificationProfile : Profile
    {
        public ClientNotificationProfile()
        {
            CreateMap<ClientNotification, ClientNotificationResultDto>()
                .ForMember(dest => dest.AppUserName, opt => opt.MapFrom(src => src.AppUser.FirstName +" "+ src.AppUser.LastName))
                .ForMember(dest => dest.AssignedUserName, opt => opt.MapFrom(src => src.AssignedToUser.FirstName +" "+ src.AssignedToUser.LastName))
                .ForMember(dest => dest.CreatedDate,opt => opt.MapFrom(src => src.CreatedDate.ToString("dd/MM/yyyy H:mm"))).ReverseMap();
            
        }
        
    }
}
