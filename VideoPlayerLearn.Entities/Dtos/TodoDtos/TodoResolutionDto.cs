using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPlayerLearn.Entities.Dtos.TodoDtos
{
    public class TodoResolutionDto
    {
        public int Id { get; set; }
        public string? ResolutionNote { get; set; }
        public int TodoStatusId { get; set; } = 3;
        public DateTime? FinishedDate { get; set; } = DateTime.Now;
    }
}
