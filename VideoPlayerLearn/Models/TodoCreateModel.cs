using Microsoft.AspNetCore.Mvc.Rendering;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos;

namespace VideoPlayerLearn.Models
{
    public class TodoCreateModel
    {
        public TodoCreateDto TodoCreateDto{ get; set; }
        public SelectList DepartmentList{ get; set; }
        public SelectList StatusList{ get; set; }
    }
}
