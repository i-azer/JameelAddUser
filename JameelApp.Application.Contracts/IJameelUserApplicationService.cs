// Ignore Spelling: Jameel App

using JameelApp.Application.Contracts.JameelUserDto;

namespace JameelApp.Application.Contracts
{
    public interface IJameelUserApplicationService
    {
        Task Add(JameelUserRequestDto input);
        Task<List<JameelUserResponseDto>> GetJameelUsers();
    }
}