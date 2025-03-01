using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topop.Domain.Models
{
    public class Ranking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserRanking> UserRankings { get; set; }
        public ICollection<VideoRanking> VideoRankings { get; set; }

    }
}
