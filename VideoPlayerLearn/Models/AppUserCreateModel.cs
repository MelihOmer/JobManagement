using Microsoft.AspNetCore.Mvc.Rendering;
using VideoPlayerLearn.Entities.Dtos;

namespace VideoPlayerLearn.Models
{
    public class AppUserCreateModel
    {
        public AppUserCreateDto  AppUserCreateDto{ get; set; }
        public SelectList DepartmentList{ get; set; }
        public SelectList RoleList{ get; set; }
    }
}
