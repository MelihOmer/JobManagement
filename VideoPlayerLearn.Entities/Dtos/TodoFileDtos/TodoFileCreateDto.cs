using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Entities.Common;

namespace VideoPlayerLearn.Entities.Dtos.TodoFileDtos
{
    public class TodoFileCreateDto
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int TodoId { get; set; }
    }
}
