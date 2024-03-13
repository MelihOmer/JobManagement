namespace VideoPlayerLearn.Entities.Dtos.TodoDtos
{
    public class TodoReviewDto
    {
        public TodoReviewDto()
        {
            
        }
        public TodoReviewDto(int todoId)
        {
            Id = todoId;
        }
        public int Id { get; set; }
        public string? ReviewNote { get; set; }
        public int TodoStatusId { get; set; } = 2;
        public DateTime? AnalysisStartDate { get; set; } = DateTime.Now;
    }
}
