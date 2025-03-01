
namespace topop.Domain.Models
{
    public class UserRanking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int RankingId { get; set; }
        public Ranking Ranking { get; set; }
    }
}
