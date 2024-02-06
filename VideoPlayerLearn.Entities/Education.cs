using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Entities.Common;

namespace VideoPlayerLearn.Entities
{
    public class Education : BaseEntity, IDefaultEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? VideoPath { get; set; }
        public string? ImagePath { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int EduEducationCategoryId { get; set; }
        public EducationCategory EducationCategory { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
