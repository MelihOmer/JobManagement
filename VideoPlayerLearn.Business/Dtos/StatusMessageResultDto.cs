namespace VideoPlayerLearn.Business.Dtos
{
    public class StatusMessageResultDto
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public string UserImagePath { get; set; }
        public int StatusUserId { get; set; }
        public string StatusContent { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
