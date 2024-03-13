namespace VideoPlayerLearn.Entities.Dtos.TodoDtos
{
    public class TodoResolutionDto
    {
        public TodoResolutionDto()
        {
            
        }
        public TodoResolutionDto(int todoId)
        {
            Id = todoId;

        }
        public int Id { get; set; }
        public string? ResolutionNote { get; set; }
        public int TodoStatusId { get; set; } = 3;
        public DateTime? FinishedDate { get; set; } = DateTime.Now;
    }
}
