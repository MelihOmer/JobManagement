using Microsoft.AspNetCore.Mvc.Rendering;
using VideoPlayerLearn.Business.Dtos;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos;
using VideoPlayerLearn.Entities.Dtos.TodoDtos;

namespace VideoPlayerLearn.Models
{
    public class TodoDetailsWithTodoCommentsModel
    {
 
        public Todo Todo { get; set; }
        //public List<TodoComment> TodoComments { get; set; }
        //public TodoCommentCreateDto TodoCommentCreate { get; set; }
        public List<TodoFile> TodoFiles { get ; set; }
        public TodoResolutionDto ResolutionDto{ get; set; }
        public TodoReviewDto ReviewDto { get; set; }
        public TodoAssignDto TodoAssignDto { get; set; }
        public TodoRejectedDto TodoRejectedDto { get; set; }
        public SelectList UserList{ get; set; }
        public List<TodoViewsUserDto> UserViewsTodo{ get; set; }
        public ClientNotification ClientNotification { get; set; }
    }
}
