using VideoPlayerLearn.Entities.Common;

namespace VideoPlayerLearn.Entities
{
    public class TodoViewsUser:BaseEntity
    {
        public TodoViewsUser()
        {
            
        }
        public TodoViewsUser(int _todoId,int _appUserId)
        {
            TodoId = _todoId;
            AppUserId = _appUserId;
        }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public Todo Todo { get; set; }
        public int TodoId { get; set; }
    }
}
