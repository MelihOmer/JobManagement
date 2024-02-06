using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.TagHelpers
{

    [HtmlTargetElement("newWorks")]
    public class NewWorks :TagHelper
    {
        public int UserId { get; set; }
        private readonly UserManager<AppUser> _userManager;
        private readonly ITodoService _todoService;

        public NewWorks(UserManager<AppUser> userManager, ITodoService todoService)
        {
            _userManager = userManager;
            _todoService = todoService;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == UserId);
            int newWorkCount = _todoService.GetAllQueryable().Where(x => x.DepartmentId == user.DepartmentId && x.TodoStatusId == 1 ).Count();
            string html = newWorkCount.ToString();

            output.Content.SetHtmlContent(html);


           
        }
    }
}
