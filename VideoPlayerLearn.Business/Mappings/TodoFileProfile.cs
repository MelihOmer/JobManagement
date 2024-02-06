using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos.TodoFileDtos;

namespace VideoPlayerLearn.Business.Mappings
{
    public class TodoFileProfile : Profile
    {
        public TodoFileProfile()
        {
            CreateMap<TodoFile, TodoFileCreateDto>().ReverseMap();
        }
    }
}
