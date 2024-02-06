using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
