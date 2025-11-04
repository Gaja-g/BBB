using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBB.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public DateTime? LastLogin { get; set; }

        public int RoleId { get; set; }
        public virtual AppRole Role { get; set; } = null!;

        // Remove Auth — Identity handles password and tokens internally

        public virtual ICollection<BoardGameUser> BoardGameUsers { get; set; } = new List<BoardGameUser>();
    }
}
