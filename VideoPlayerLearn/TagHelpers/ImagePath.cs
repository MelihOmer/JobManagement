using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.TagHelpers
{
    [HtmlTargetElement("ImagePath")]
    public class ImagePath:TagHelper
    {
        public string UserName { get; set; }
        public readonly UserManager<AppUser> _userManager;

        public ImagePath(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
           var user =  await _userManager.FindByNameAsync(UserName);
            output.Content.SetHtmlContent(user.ImagePath);
        }
    }
}
