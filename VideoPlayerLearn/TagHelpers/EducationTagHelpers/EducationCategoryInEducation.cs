using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using VideoPlayerLearn.Business.Abstract;

namespace VideoPlayerLearn.TagHelpers.EducationTagHelpers
{
    [HtmlTargetElement("educationCount")]
    public class EducationCategoryInEducation:TagHelper
    {
        private readonly IEducationService _educationService;
        public string CategoryId { get; set; }
        public EducationCategoryInEducation(IEducationService educationService)
        {
            _educationService = educationService;
        }
        
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var result = _educationService.GetAllQueryable().Where(x => x.EduEducationCategoryId == int.Parse(CategoryId)).Count();

            output.Content.SetHtmlContent(result.ToString());
        }
    }
}
