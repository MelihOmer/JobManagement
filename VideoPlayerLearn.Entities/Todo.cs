using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Entities.Common;

namespace VideoPlayerLearn.Entities
{
    public class Todo :BaseEntity,IDefaultEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime? FinishedDate { get; set; }
        public List<TodoComment> TodoComments { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int TodoStatusId { get; set; }
        public TodoStatus TodoStatus { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
