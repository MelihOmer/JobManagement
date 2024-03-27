using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VideoPlayerLearn.Business.Abstract;

namespace VideoPlayerLearn.CustomActionFilterAttributes
{
    public class SeeNotificationNotSeenByLoginUser : IAsyncActionFilter
    {
        private readonly IClientNotificationService _clientNotificationService;

        public SeeNotificationNotSeenByLoginUser(IClientNotificationService clientNotificationService)
        {
            _clientNotificationService = clientNotificationService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ActionArguments.ContainsKey("Id"))
            {
                int todoId = int.Parse(context.ActionArguments["Id"].ToString());
                await _clientNotificationService.NotifyNotSeenForAppUserAsync(todoId);
                await _clientNotificationService.NotifyNotSeenForAssignedUserAsync(todoId);  
            }
            await next();
        }
    }
}
