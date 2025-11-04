namespace BBB.Models
{
    public class BoardGameUser
    {
        public int Id { get; set; }

        public int BoardGameId { get; set; }
        public virtual BoardGame BoardGame { get; set; } = null!;

        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;

        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
