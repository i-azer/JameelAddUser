// Ignore Spelling: Jameel App

using AutoMapper;
using JameelApp.Application.Contracts;
using JameelApp.Application.Contracts.JameelUserDto;
using JameelApp.Domain;
using JameelApp.EntityFramework.SQLServer;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace JameelApp.Application
{
    public class JameelUserApplicationService : IJameelUserApplicationService
    {
        private readonly JameelDatabaseContext _context;
        private IMapper _iMapper;
        private readonly SequentialGuidValueGenerator _guidGenerator;
        public JameelUserApplicationService(JameelDatabaseContext context)
        {
            _context = context;
            _guidGenerator = new SequentialGuidValueGenerator();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JameelUserRequestDto, JameelUser>();
                cfg.CreateMap<JameelUser, JameelUserResponseDto>();
            });

            _iMapper = config.CreateMapper();
        }
        public async Task<JameelUserResponseDto> Add(JameelUserRequestDto input)
        { 
            var jameelNewUser = _iMapper.Map<JameelUser>(input);
            var addedUser = await _context.AddAsync(jameelNewUser);
            _ = _guidGenerator.Next(addedUser);
            await _context.SaveChangesAsync();
            return _iMapper.Map<JameelUserResponseDto>(addedUser.Entity);
        }
    }
}