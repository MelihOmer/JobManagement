namespace VideoPlayerLearn.Business.Dtos
{
    public class TodoCommentNotifyDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public int AppUserId { get; set; }
        public int? AssignedUserId { get; set; }

    }
}
