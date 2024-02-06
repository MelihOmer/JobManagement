using Microsoft.AspNetCore.Http;

namespace VideoPlayerLearn.Entities.Dtos
{
    public class TodoCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AppUserId { get; set; } 
        public int AssignedToUserId { get; set; } = 2;
        public int TodoStatusId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public IFormFile File{ get; set; }
    }
}
