// Ignore Spelling: Jameel App

using AutoMapper;
using JameelApp.Application.Contracts;
using JameelApp.Application.Contracts.JameelUserDto;
using JameelApp.Domain;
using JameelApp.EntityFramework.SQLServer;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace JameelApp.Application
{
    public class JameelUserApplicationService : IJameelUserApplicationService
    {
        private readonly JameelDatabaseContext _context;
        private readonly IMapper _iMapper;
        private readonly SequentialGuidValueGenerator _guidGenerator;
        private readonly IHubContext<JameelUserHubBroadcaster, IJameelUserHubBroadcaster> _jameelUserHubBroadcaster;

        public JameelUserApplicationService(JameelDatabaseContext context,
            IHubContext<JameelUserHubBroadcaster, IJameelUserHubBroadcaster> jameelUserHubBroadcaster)
        {
            _context = context;
            _jameelUserHubBroadcaster = jameelUserHubBroadcaster;
            _guidGenerator = new SequentialGuidValueGenerator();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JameelUserRequestDto, JameelUser>();
                cfg.CreateMap<JameelUser, JameelUserResponseDto>()
                .ForMember(mem => mem.DateOfBirth, op => op
                .MapFrom(src => DateOnly
                .FromDateTime(src.DateOfBirth)));
            });

            _iMapper = config.CreateMapper();
        }
        public async Task Add(JameelUserRequestDto input)
        {
            var jameelNewUser = _iMapper.Map<JameelUser>(input);
            var addedUser = await _context.AddAsync(jameelNewUser);
            var newUserId = _guidGenerator.Next(addedUser);
            try
            {
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Issue Occurred During Insertion !! Hangfire Please Retry");
            }
        }


        public async Task<List<JameelUserResponseDto>> GetJameelUsers()
        {
            var usersList = await _context.JameelUsers.ToListAsync();
            if (usersList.Count > 0)
            {
                return _iMapper.Map<List<JameelUserResponseDto>>(usersList);
            }
            return Enumerable.Empty<JameelUserResponseDto>().ToList();

        }
    }
}