// Ignore Spelling: Jameel Dto

namespace JameelApp.Application.Contracts.JameelUserDto
{
    public class JameelUserRequestDto
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
    }
}
