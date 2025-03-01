using topop.Infrastructure.Repository.Imp;
using topop.Infrastructure.Repository.Interface;
using topop.Infrastructure.UnitOfWork.Interface;

namespace topop.Infrastructure.UnitOfWork.Imp
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IVideoRepository? _videoRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IVideoRepository VideoRepository => _videoRepository ??= new VideoRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

