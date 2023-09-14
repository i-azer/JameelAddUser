// Ignore Spelling: Jameel App

using JameelApp.Application.Contracts.JameelUserDto;

namespace JameelApp.Application.Contracts
{
    public interface IJameelUserApplicationService
    {
        Task<JameelUserResponseDto> Add(JameelUserRequestDto input);
    }
}