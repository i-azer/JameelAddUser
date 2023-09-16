// Ignore Spelling: App Jameel

namespace JameelApp.Domain
{
    public class JameelUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime CreationDate { get; set; }
    }
}