// Ignore Spelling: Jameel Dto App

using System.Text.Json.Serialization;

namespace JameelApp.Application.Contracts.JameelUserDto
{
    public class JameelUserResponseDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
