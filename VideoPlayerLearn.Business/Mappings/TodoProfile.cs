using AutoMapper;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos;
using VideoPlayerLearn.Entities.Dtos.TodoDtos;

namespace VideoPlayerLearn.Business.Mappings
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<Todo, TodoCreateDto>().ReverseMap();
            CreateMap<Todo,TodoUpdateDto>().ReverseMap();
            CreateMap<Todo, TodoResolutionDto>().ReverseMap();
            CreateMap<Todo,TodoReviewDto>().ReverseMap();
            CreateMap<Todo,TodoRejectedDto>().ReverseMap();
        }
    }
}
