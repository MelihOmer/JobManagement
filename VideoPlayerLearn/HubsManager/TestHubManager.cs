using Microsoft.AspNetCore.SignalR;
using VideoPlayerLearn.Hubs;

namespace VideoPlayerLearn.HubsManager
{
    public class TestHubManager
    {
        private readonly IHubContext<TestHub> hubContext;

        public TestHubManager(IHubContext<TestHub> hubContext)
        {
            this.hubContext = hubContext;
        }
        public async Task SendMessage(string userId,string message)
        {
            await hubContext.Clients.User(userId).SendAsync(message);
        }
    }
        
}
