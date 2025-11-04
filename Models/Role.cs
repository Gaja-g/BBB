namespace BBB.Models
{
    public class AppRole
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public virtual List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}
