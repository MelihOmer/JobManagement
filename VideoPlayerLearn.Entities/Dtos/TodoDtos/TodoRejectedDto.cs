namespace VideoPlayerLearn.Entities.Dtos.TodoDtos
{
    public class TodoRejectedDto
    {
        public TodoRejectedDto()
        {
            
        }
        public TodoRejectedDto(int _id)
        {
            Id = _id;
        }
        public int Id { get; set; }
        public string? RejectedNote { get; set; }
        public int TodoStatusId { get; set; } = 4;
        public DateTime? RejectedDate { get; set; } = DateTime.Now;
    }
}
