using Microsoft.EntityFrameworkCore;
using topop.Domain.Models;
using topop.Infrastructure.Repository.Interface;


namespace topop.Infrastructure.Repository.Imp
{
    public class VideoRepository : IVideoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VideoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Video>> GetAllAsync() => await _dbContext.Videos.ToListAsync();

        public async Task<Video?> GetByIdAsync(int id) => await _dbContext.Videos.FindAsync(id);

        public async Task AddAsync(Video video)
        {
            await _dbContext.Videos.AddAsync(video);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Video video)
        {
            _dbContext.Videos.Update(video);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var video = await _dbContext.Videos.FindAsync(id);
            if (video != null)
            {
                _dbContext.Videos.Remove(video);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
