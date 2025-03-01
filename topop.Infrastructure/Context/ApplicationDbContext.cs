using Microsoft.EntityFrameworkCore;
using topop.Domain.Models;

namespace topop.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Ranking> Rankings { get; set; }
        public DbSet<UserRanking> UserRankings { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<UserVideoRanking> UserVideoRankings { get; set; }
        public DbSet<VideoRanking> VideoRankings { get; set; }
        public DbSet<UserRol> UserRols { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<UserRanking>()
                .HasKey(ur => ur.Id);
            modelBuilder.Entity<UserRanking>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRankings)
                .HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<UserRanking>()
                .HasOne(ur => ur.Ranking)
                .WithMany(r => r.UserRankings)
                .HasForeignKey(ur => ur.RankingId);

            modelBuilder.Entity<UserVideoRanking>()
                .HasKey(uvr => uvr.Id);
            modelBuilder.Entity<UserVideoRanking>()
                .HasOne(uvr => uvr.User)
                .WithMany(u => u.UserVideoRanking)
                .HasForeignKey(uvr => uvr.UserId);
            modelBuilder.Entity<UserVideoRanking>()
                .HasOne(uvr => uvr.VideoRanking)
                .WithMany(vr => vr.UserVideoRanking)
                .HasForeignKey(uvr => uvr.VideoRankingId);

            modelBuilder.Entity<VideoRanking>()
                .HasKey(vr => vr.Id);
            modelBuilder.Entity<VideoRanking>()
                .HasOne(vr => vr.Video)
                .WithMany(v => v.VideoRankings)
                .HasForeignKey(vr => vr.VideoId);
            modelBuilder.Entity<VideoRanking>()
                .HasOne(vr => vr.Ranking)
                .WithMany(r => r.VideoRankings)
                .HasForeignKey(vr => vr.RankingId);
        }
    }
}
