using AutoMapper;
using VideoPlayerLearn.Business.Dtos;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos;

namespace VideoPlayerLearn.Business.Mappings
{
    public class TodoCommentProfile : Profile
    {
        public TodoCommentProfile()
        {
            CreateMap<TodoComment, TodoCommentCreateDto>().ReverseMap();
            CreateMap<TodoComment, TodoCommentResultDto>()
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.AppUser.ImagePath))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.AppUser.FirstName + src.AppUser.LastName))
                .ReverseMap();
        }
    }
}
