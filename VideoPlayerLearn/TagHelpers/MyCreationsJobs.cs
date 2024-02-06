using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.TagHelpers
{

    [HtmlTargetElement("MyCreationsJobs")]
    public class MyCreationsJobs : TagHelper
    {
        public string UserId { get; set; }
        private readonly ITodoService _todoService;

        public MyCreationsJobs(ITodoService todoService)
        {
            _todoService = todoService;

        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var count = _todoService.GetAllQueryable().Where(x => x.AppUserId == int.Parse(UserId)).Count();
            output.Content.SetHtmlContent(count.ToString());
        }
    }
}
