using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Models;

namespace VideoPlayerLearn.Models
{
    public class EducationListVM
    {
        public List<Education> Educations { get; set; }
        public string TitleFilter { get; set; }
        public List<EducationWithCategoryListModel> CategoryList{ get; set; }
        public virtual int CurrentPage { get; set; }
        public virtual int PageSize { get; set; }
        public virtual int TotalCount { get; set; }
        public virtual int TotalPages { get; set; }
        public virtual bool ShowPrevious => CurrentPage > 1;
        public virtual bool ShowNext => CurrentPage < TotalPages;
        public virtual bool IsAscending { get; set; }


    }
}
