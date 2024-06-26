﻿namespace VideoPlayerLearn.Entities.Dtos
{
    public class TodoCommentCreateDto
    {
        public string Definition { get; set; }
        public int TodoId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int AppUserId { get; set; }
        public int AssignedToUserId { get; set; }
    }
}
