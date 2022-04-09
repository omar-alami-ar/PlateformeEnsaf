using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using PlateformeEnsaf.Models;
using System;
using System.Threading.Tasks;

[HubName("MessageHub")]
public class MessageHub : Hub
{

    public async Task SendMessage(string user, string message,string receiverId)
    {
        await Clients.Others.SendAsync("ReceiveMessage", user, message,receiverId);
    }

    public async Task SendNotification(string user)
    {
        await Clients.Others.SendAsync("ReceiveNotification", user);
    }

    //public async Task SendMessage(string user, string message)
    //{
    //    await Clients.All.SendAsync("ReceiveMessage", user, message);
    //}

    public async Task SendToUser(string user, string receiverConnectionId, string message)
    {
        await Clients.Client(receiverConnectionId).SendAsync("ReceiveMessage", user, message);
    }

    public string GetConnectionId() => Context.ConnectionId;

    public override Task OnConnectedAsync()
    {
        ApplicationUser.Ids.Add(Context.ConnectionId);
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        ApplicationUser.Ids.Remove(Context.ConnectionId);
        return base.OnDisconnectedAsync(exception);
    }
}