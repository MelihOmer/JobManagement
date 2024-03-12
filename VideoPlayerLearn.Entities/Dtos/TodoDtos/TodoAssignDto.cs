namespace VideoPlayerLearn.Entities.Dtos.TodoDtos
{
    public class TodoAssignDto
    {
        public TodoAssignDto()
        {
            
        }
        public TodoAssignDto(int _todoId,int? _oldUserId)
        {
            TodoId = _todoId;
            OldUserId = _oldUserId;
        }
        public int TodoId { get; set; }
        public int? OldUserId { get; set; }
        public int NewUserId { get; set; }
        public string AssignNote { get; set; }
    }
}
