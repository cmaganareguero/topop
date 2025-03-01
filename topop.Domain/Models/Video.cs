using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topop.Domain.Models
{
    public class Video
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Anime { get; set; }
        public string Type  { get; set; }

        public ICollection<VideoRanking> VideoRankings { get; set; }    }
}
