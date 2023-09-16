// Ignore Spelling: Jameel App Hangfire

using Hangfire;
using JameelApp.Application.Contracts;
using JameelApp.Application.Contracts.JameelUserDto;
using System;
using System.Threading.Tasks;

namespace JameelApp.Hangfire
{
    public class JameelUserOffLoader : IJameelUserOffLoader
    {
        private readonly IJameelUserApplicationService _jameelUserApplicationService;
        public JameelUserOffLoader(IJameelUserApplicationService jameelUserApplicationService)
        {
            _jameelUserApplicationService = jameelUserApplicationService;
        }
        public async Task InsertIntoDatabase(JameelUserRequestDto input)
        {
            await Task.Run(() =>
            {
                BackgroundJob
                              .Schedule(() =>
                              _jameelUserApplicationService.Add(input),
                              TimeSpan.FromMinutes(5));

            });
        }
    }
}
