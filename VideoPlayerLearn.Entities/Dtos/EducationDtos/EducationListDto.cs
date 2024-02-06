using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.Business
{
    public class EducationListDto
    {
        public List<Education> Educations { get; set; }
        public virtual int CurrentPage { get; set; }
        public virtual int PageSize { get; set; }
        public virtual int TotalCount { get; set; }
        public virtual int TotalPages { get => (int)Math.Ceiling(decimal.Divide(TotalCount, PageSize)); }
        public virtual bool ShowPrevious => CurrentPage > 1;
        public virtual bool ShowNext => CurrentPage < TotalPages;
        public virtual bool IsAscending { get; set; }
    }
}
