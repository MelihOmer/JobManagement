using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.TagHelpers
{
    [HtmlTargetElement("assignRole")]
    public class AssingRole :TagHelper
    {
        public int UserId { get; set; }
        private readonly UserManager<AppUser> _userManager;

        public AssingRole(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string html = "";
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == UserId);

            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Count > 0)
            {
                foreach (var role in roles)
                {
                    html += role + " ";
                }
            }
            else
            {
                html = @"<strong class='text-danger'>Rol Bilgisi Bulunamadı</strong>";
            }

                output.Content.SetHtmlContent(html);

            
        }
    }
}
