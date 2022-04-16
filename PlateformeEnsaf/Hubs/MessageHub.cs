using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using PlateformeEnsaf.Models;
using System;
using System.Threading.Tasks;

[HubName("MessageHub")]
public class MessageHub : Hub
{
    static long counter = 0;

    public async Task SendMessage(string user, string message,string receiverId)
    {
        await Clients.Others.SendAsync("ReceiveMessage", user, message,receiverId);
    }

    public async Task SendNotification(string user, int annonceId)
    {
        await Clients.Others.SendAsync("ReceiveNotification", user, annonceId);
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
        ApplicationUser.AddOnly(Context.UserIdentifier);
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        ApplicationUser.RemoveOnly(Context.UserIdentifier);
        return base.OnDisconnectedAsync(exception);
    }
}