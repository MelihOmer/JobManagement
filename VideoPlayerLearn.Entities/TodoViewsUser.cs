using VideoPlayerLearn.Entities.Common;

namespace VideoPlayerLearn.Entities
{
    public class TodoViewsUser:BaseEntity
    {
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public Todo Todo { get; set; }
        public int TodoId { get; set; }
    }
}
