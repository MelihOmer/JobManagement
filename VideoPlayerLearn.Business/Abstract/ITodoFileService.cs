using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos.TodoFileDtos;

namespace VideoPlayerLearn.Business.Abstract
{
    public interface ITodoFileService : IService<TodoFile>
    {
        Task CreateTodoFile(TodoFileCreateDto model, IFormFile file);
        Task<byte[]> GetDownloadFile(string name);
    }
}
