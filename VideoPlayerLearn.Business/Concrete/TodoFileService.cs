using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.DataAccess.UnitOfWork;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos.TodoFileDtos;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace VideoPlayerLearn.Business.Concrete
{
    public class TodoFileService : Service<TodoFile>, ITodoFileService
    {
        private readonly IHostingEnvironment _environment;

        private readonly IMapper _mapper;

        public TodoFileService(IUow uow, IMapper mapper, IHostingEnvironment environment) : base(uow, mapper)
        {
            _environment = environment;
            _mapper = mapper;
        }

        private async Task<(string,string,string)> FileSave(IFormFile file)
        {
            if (file.Length > 0)
            {
                string wwwroot = _environment.WebRootPath;
                var extension = Path.GetExtension(file.FileName);
                var fileName = $"{Guid.NewGuid().ToString()}{extension}";
                string path = $"{wwwroot}/TodoFiles/{fileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return ($"/TodoFiles/{fileName}",fileName,file.FileName);
            }
            return ("Dosya Yok","","");
        }
        public async Task CreateTodoFile(TodoFileCreateDto model,IFormFile file)
        {
           var path = await FileSave(file);
            

            var entity = _mapper.Map<TodoFile>(model);
            entity.FilePath = path.Item1;
            entity.FileName = path.Item2;
            entity.RealFileName = path.Item3;
            await CreateAsync(entity);
        }
        public async Task<byte[]> GetDownloadFile(string name)
        {
            string path = _environment.WebRootPath+"/TodoFiles/" +  name;
            byte[] bytes = await File.ReadAllBytesAsync(path);
            return bytes;
        }
        public async Task<List<TodoFile>> GetTodoFilesByTodoIdAsync(int todoId)
        {
          return  await GetAllQueryable()
                .Where(x => x.TodoId == todoId)
                .ToListAsync();
        }
    }
}
