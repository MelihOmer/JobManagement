using Microsoft.AspNetCore.Mvc;
using VideoPlayerLearn.Business.Abstract;

namespace VideoPlayerLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoFilesController : ControllerBase
    {
        readonly ITodoFileService _todoFiles;

        public TodoFilesController(ITodoFileService todoFiles)
        {
            _todoFiles = todoFiles;
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> TodoFileUpload(int id,List<IFormFile> files)
        {
            var userFullName = User.Claims.Where(x => x.Type == "UserFirstLastName").FirstOrDefault();
            if (files is null || files.Count == 0)
            {
                return BadRequest("Dosya Seçilmedi Veya Boş");
            }
            foreach (var item in files)
            {
                await _todoFiles.CreateTodoFile(new(todoId: id), item);
            }
            string fileNames = "";
            int i = 0;
            foreach (var item in files)
            {
                fileNames += item.FileName;
                if (i < files.Count-1)
                {
                    fileNames += ", ";
                    i++;
                }
                
            }
            return Ok($"{userFullName.Value} Bildirime Dosyalar Ekledi <strong class='text-success'>({fileNames})</strong>");
        }


    }
}
