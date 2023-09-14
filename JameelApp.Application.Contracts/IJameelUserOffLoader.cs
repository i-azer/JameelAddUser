// Ignore Spelling: Jameel

using JameelApp.Application.Contracts.JameelUserDto;

namespace JameelApp.Application.Contracts
{
    public interface IJameelUserOffLoader
    {
        Task InsertIntoDatabase(JameelUserRequestDto input);
    }
}
