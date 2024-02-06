using Microsoft.AspNetCore.Mvc.Rendering;
using VideoPlayerLearn.Entities.Dtos;

namespace VideoPlayerLearn.Models
{
    public class AppUserDetailModel
    {
        public AppUserUpdateDto AppUserUpdateDto { get; set; }
        public SelectList DepartmentList{ get; set; }
    }
}
