namespace VideoPlayerLearn.Entities.Dtos.TodoDtos
{
    public class TodoResolutionDto
    {
        public TodoResolutionDto()
        {
            
        }
        public TodoResolutionDto(int _id)
        {
               Id = _id;
        }
        public int Id { get; set; }
        public string? ResolutionNote { get; set; }
        public int TodoStatusId { get; set; } = 3;
        public DateTime? FinishedDate { get; set; } = DateTime.Now;
    }
}
