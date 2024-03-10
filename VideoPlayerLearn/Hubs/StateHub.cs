using Microsoft.AspNetCore.SignalR;

namespace VideoPlayerLearn.Hubs
{
    public class StateHub : Hub
    {
        public async Task SendState(string stateText)
        {
            //await Clients.All.SendAsync("ReceiveState", stateText);
        }
    }
}
