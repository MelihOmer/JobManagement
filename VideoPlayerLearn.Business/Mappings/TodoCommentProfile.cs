using AutoMapper;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos;

namespace VideoPlayerLearn.Business.Mappings
{
    public class TodoCommentProfile : Profile
    {
        public TodoCommentProfile()
        {
            CreateMap<TodoComment, TodoCommentCreateDto>().ReverseMap();
        }
    }
}
