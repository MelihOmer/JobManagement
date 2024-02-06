using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.TagHelpers
{
    [HtmlTargetElement("AllWorkForDepartment")]
    public class AllWorkForDepartment :TagHelper
    {
        public string UserId { get; set; }
        private readonly UserManager<AppUser> _userManager;
        private readonly ITodoService _todoService;

        public AllWorkForDepartment(ITodoService todoService, UserManager<AppUser> userManager)
        {
            _todoService = todoService;
            _userManager = userManager;
        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await _userManager.FindByIdAsync(UserId);
            var count = _todoService.GetAllQueryable().Where(x => x.DepartmentId == user.DepartmentId).Where(x => x.TodoStatusId ==1 || x.TodoStatusId == 2).Where(x => x.AssignedToUserId ==2).Count();
            output.Content.SetHtmlContent(count.ToString());
        }
    }
}
