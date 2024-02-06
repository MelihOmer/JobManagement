using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPlayerLearn.Entities.Dtos.TodoDtos
{
    public class TodoRejectedDto
    {
        public int Id { get; set; }
        public string? RejectedNote { get; set; }
        public int TodoStatusId { get; set; } = 4;
        public DateTime? RejectedDate { get; set; } = DateTime.Now;
    }
}
