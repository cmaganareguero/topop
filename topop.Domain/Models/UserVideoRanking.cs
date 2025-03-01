
namespace topop.Domain.Models
{
    public class UserVideoRanking
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int VideoRankingId { get; set; }
        public VideoRanking VideoRanking { get; set; }
    }
}
