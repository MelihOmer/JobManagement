using Microsoft.AspNetCore.Mvc.Rendering;
using VideoPlayerLearn.Entities.Dtos;

namespace VideoPlayerLearn.Models
{
    public class TodoUpdateModel
    {


        public TodoUpdateDto TodoUpdateDto { get; set; }
        public SelectList DepartmentList { get; set; }
        public SelectList StatusList { get; set; }
        public SelectList UserList { get; set; }
    }
}
