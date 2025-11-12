namespace BBB.Models
{
    public class BoardGameUserDecisionDto
    {
        public int BoardGameUserId { get; set; }
        public int Result { get; set; } // 0 = untouched, 1 = approved, 2 = denied
    }
}
