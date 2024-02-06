using Microsoft.AspNetCore.Mvc.Rendering;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.Models
{

    public class EducationCreateModel
    {
        public Education Education{ get; set; }
        public SelectList Departments { get; set; }
        public SelectList EducationCategories { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile Video { get; set; }
    }
}
