namespace BBB.Models
{
    public class Auth
    {
        public int Id { get; set; }

        public string PasswordHash { get; set; } = string.Empty;
        public string? Token { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
