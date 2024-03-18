using Microsoft.AspNetCore.SignalR;
using VideoPlayerLearn.Business.Extensions;
using VideoPlayerLearn.Hubs;

namespace VideoPlayerLearn.HubManager
{
    public class TestHubManager
    {
        readonly IHubContext<TestHub> _testHubContext;
        readonly IHttpContextAccessor _contextAccessor;
        string _loggedInUserId;
        public TestHubManager(IHubContext<TestHub> testHubContext, IHttpContextAccessor contextAccessor)
        {
            _testHubContext = testHubContext;
            _contextAccessor = contextAccessor;
            _loggedInUserId = _contextAccessor.HttpContext.User.GetLoggedInUserId().ToString();
        }

        public async Task AfterAddingCommentNotify(int appUserId,int assignedUserId,int todoId)
        {
            var usersToSendList = CheckAppUserAndAssignedUserNotfiy(appUserId,assignedUserId);
            await _testHubContext.Clients.Users(usersToSendList).SendAsync("ReceiveMessage", $"{todoId} Nolu Bildirime Yorum Eklendi...");
        }
        private List<string> CheckAppUserAndAssignedUserNotfiy(int appUserId,int assignedUserId)
        {
            
            List<string> usersToSendList = new() { appUserId.ToString(),assignedUserId.ToString()};

            for (int i = 0; i <= usersToSendList.Count-1; i++)
            {
                if (usersToSendList[i] ==_loggedInUserId)
                {
                    usersToSendList.Remove(usersToSendList[i]);
                }
            }
            return usersToSendList;



        }

    }
}
