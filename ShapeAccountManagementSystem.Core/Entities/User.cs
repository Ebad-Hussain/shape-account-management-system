namespace ShapeAccountManagementSystem.Core.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[]? Password { get; set; } 
        public byte[]? Hash { get; set; } 
    }
}
