// Ignore Spelling: Jameel Dto App

using System.Text.Json.Serialization;

namespace JameelApp.Application.Contracts.JameelUserDto
{
    public class JameelUserRequestDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
    }
}
