// Ignore Spelling: Jameel App

using JameelApp.Application.Contracts.JameelUserDto;

namespace JameelApp.Application.Contracts
{
    public interface IJameelUserHubBroadcaster
    {
        Task BroadcastingNewUser(JameelUserResponseDto output);
    }
}
