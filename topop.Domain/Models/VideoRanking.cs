
namespace topop.Domain.Models
{
    public class VideoRanking
    {
        public int Id { get; set; } 
        public int VideoId { get; set; }
        public Video Video { get; set; }
        public int RankingId { get; set; }
        public Ranking Ranking { get; set; }
        public ICollection<UserVideoRanking> UserVideoRanking { get; set; }
    }
}
