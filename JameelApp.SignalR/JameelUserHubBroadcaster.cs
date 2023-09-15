// Ignore Spelling: Jameel App

using JameelApp.Application.Contracts;
using JameelApp.Application.Contracts.JameelUserDto;
using Microsoft.AspNetCore.SignalR;

namespace JameelApp.SignalR
{
    public class JameelUserHubBroadcaster : Hub<IJameelUserHubBroadcaster>
    {

        public override async Task OnConnectedAsync()
        {
            await Clients.All.BroadcastingNewUser(new JameelUserResponseDto { });
        }
    }
}
