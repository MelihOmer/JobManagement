using VideoPlayerLearn.Entities.Common;

namespace VideoPlayerLearn.Entities
{
    public class TodoComment : BaseEntity, IDefaultEntity
    {
        public string Definition { get; set; }
        public int TodoId { get; set; }
        public Todo Todo { get; set; }
        public DateTime CreatedDate { get ; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public bool Seen { get; set; }

    }
}
