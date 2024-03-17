namespace VideoPlayerLearn.Entities.Dtos.TodoDtos
{
    public class TodoAssignDto
    {
        public TodoAssignDto()
        {
            
        }
        public TodoAssignDto(int todoId,int? oldUserId)
        {
            TodoId = todoId;
            OldUserId = oldUserId;
        }
        public int TodoId { get; set; }
        public int? OldUserId { get; set; }
        public int NewUserId { get; set; }
        public string AssignNote { get; set; }
    }
}
