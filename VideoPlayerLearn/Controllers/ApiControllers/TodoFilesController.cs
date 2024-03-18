using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.Controllers.ApiControllers
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
        public async Task<IActionResult> TodoFileUpload(int id, List<IFormFile> files)
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
                if (i < files.Count - 1)
                {
                    fileNames += ", ";
                    i++;
                }

            }
            return Ok($"{userFullName.Value} Bildirime Dosyalar Ekledi <strong class='text-success'>({fileNames})</strong>");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoFileList(int id)
        {
            IList<TodoFile> values = await _todoFiles.GetTodoFilesByTodoIdAsync(id);
            return Ok(values);
        }
        [HttpGet("Download/{fileName}")]
        public async Task<FileResult> DownloadFile([FromRoute]string fileName)
        {
            var bytes = await _todoFiles.GetDownloadFile(fileName);
            return File(bytes, "application/octet-stream", fileName);
        }
        

    }
}
