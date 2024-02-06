using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPlayerLearn.Entities.Dtos
{
    public class TodoUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public int TodoStatusId { get; set; }
        public int AssignedToUserId { get; set; }
        public int AppUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ResolutionNote { get; set; }


    }
}
