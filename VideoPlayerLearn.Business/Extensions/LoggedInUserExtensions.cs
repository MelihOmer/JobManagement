using System.Security.Claims;

namespace VideoPlayerLearn.Business.Extensions
{
    public static class LoggedInUserExtensions
    {
        public static int GetLoggedInUserId(this ClaimsPrincipal principal)
        {
            return int.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier));
        }
        public static string GetLoggedInUserName(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Name);
        }
    }
}
