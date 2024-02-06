using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.TagHelpers
{
    [HtmlTargetElement("userWorksFilter")]
    public class MyWorksFilterCount : TagHelper
    {
        public string userId { get; set; }
        public string statusId { get; set; }
        private readonly ITodoService _todoService;

        public MyWorksFilterCount(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            var todoCount = _todoService.GetAllQueryable().Where(x => x.AppUserId == int.Parse(userId) & x.TodoStatusId == int.Parse(statusId)).Count();

            output.Content.SetHtmlContent(todoCount.ToString());
        }
    }
}
