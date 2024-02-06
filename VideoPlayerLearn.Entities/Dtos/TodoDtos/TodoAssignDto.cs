using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPlayerLearn.Entities.Dtos.TodoDtos
{
    public class TodoAssignDto
    {
        public int TodoId { get; set; }
        public int? OldUserId { get; set; }
        public int NewUserId { get; set; }
        public string AssignNote { get; set; }
    }
}
