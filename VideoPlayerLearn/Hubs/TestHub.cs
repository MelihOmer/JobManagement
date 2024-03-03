using Microsoft.AspNetCore.SignalR;

namespace VideoPlayerLearn.Hubs
{
    public class TestHub : Hub
    {
        public async Task SendMessage()
        {

            //await Clients.User("3").SendAsync("ReceiveMessage", "signalR Mesaj Gönderiyor...");
            //await Clients.User("4").SendAsync("ReceiveMessage", "4. nolu usere mesaj gönderiliyor...");
            //await Clients.All.SendAsync("ReceiveMessage", "signalR Mesaj Gönderiyor...");

            //await Task.Delay(5000);
            //await Clients.All.SendAsync("ReceiveMessage", "2signalR Mesaj Gönderiyor...");
            
        }
    }
}
