using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPlayerLearn.Entities.Dtos.TodoDtos
{
    public class TodoReviewDto
    {
        public int Id { get; set; }
        public string? ReviewNote { get; set; }
        public int TodoStatusId { get; set; } = 2;
        public DateTime? AnalysisStartDate { get; set; } = DateTime.Now;
    }
}
