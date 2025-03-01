using System.Collections.Generic;

namespace topop.Domain.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public ICollection<UserRanking> UserRankings { get; set; }
        public ICollection<UserVideoRanking> UserVideoRanking { get; set; }
        public ICollection<UserRol> UserRol { get; set; }

    }
}
