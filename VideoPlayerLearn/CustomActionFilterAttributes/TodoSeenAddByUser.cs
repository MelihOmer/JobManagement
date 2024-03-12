using Microsoft.AspNetCore.Mvc.Filters;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Business.Extensions;

namespace VideoPlayerLearn.CustomActionFilterAttributes
{
    public class TodoSeenAddByUser : IAsyncActionFilter
    {
        private readonly ITodoViewsUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;



        public TodoSeenAddByUser(ITodoViewsUserService userService, IHttpContextAccessor contextAccessor)
        {
            _userService = userService;
            _contextAccessor = contextAccessor;

        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ActionArguments.ContainsKey("Id") && _contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var id = int.Parse(context.ActionArguments["Id"].ToString());
                int _userId = _contextAccessor.HttpContext.User.GetLoggedInUserId();
                await _userService.CreateAsync(new(id, _userId));
            }
            await next();
        }
    }
}
