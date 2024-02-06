using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.TagHelpers
{

    [HtmlTargetElement("workCount")]
    public class WorkCountFilter :TagHelper
    {
        public string UserId { get; set; }
        public int statusId { get; set; }

        private readonly ITodoService _todoService;

        public WorkCountFilter( ITodoService todoService)
        {

            _todoService = todoService;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

           
            int workCount = _todoService.GetAllQueryable().Where(x =>  x.TodoStatusId == statusId && x.AssignedToUserId == int.Parse(UserId)).Count();


            output.Content.SetHtmlContent(workCount.ToString());


           
        }
    }
}
