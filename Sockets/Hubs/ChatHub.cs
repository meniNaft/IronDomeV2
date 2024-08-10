using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
    public async Task FE_Notify(string user, string message)
    {
        await Clients.All.SendAsync("BE_Notify", user, message);
    }
}
