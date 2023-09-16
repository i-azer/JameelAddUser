// Ignore Spelling: Jameel App

using JameelApp.Application.Contracts.JameelUserDto;
using Microsoft.AspNetCore.SignalR;

namespace JameelApp.Application.Contracts
{
    public class JameelUserHubBroadcaster : Hub<IJameelUserHubBroadcaster>
    {
        private readonly IJameelUserApplicationService _jameelUserApplicationService;
        public JameelUserHubBroadcaster(IJameelUserApplicationService jameelUserApplicationService)
        {
            _jameelUserApplicationService = jameelUserApplicationService;
        }
        public async override Task OnConnectedAsync()
        {
            var initiatClientList = await _jameelUserApplicationService.GetJameelUsers();
            await Clients.Caller.JameelUserHubBroadcaster(initiatClientList);
            await base.OnConnectedAsync();
        }
        public async Task OnBroadcastingNewUser(JameelUserRequestDto jameelUser)
        {
            await Clients.AllExcept(Context.ConnectionId).BroadcastingNewUser(jameelUser);
        }
    }
}
