using Microsoft.AspNetCore.Http;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos.TodoFileDtos;

namespace VideoPlayerLearn.Business.Abstract
{
    public interface ITodoFileService : IService<TodoFile>
    {
        Task CreateTodoFile(TodoFileCreateDto model, IFormFile file);
        Task<byte[]> GetDownloadFile(string name);
        Task<List<TodoFile>> GetTodoFilesByTodoIdAsync(int todoId);
    }
}
