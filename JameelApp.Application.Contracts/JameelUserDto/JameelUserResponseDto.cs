// Ignore Spelling: Jameel Dto App

namespace JameelApp.Application.Contracts.JameelUserDto
{
    public class JameelUserResponseDto
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
