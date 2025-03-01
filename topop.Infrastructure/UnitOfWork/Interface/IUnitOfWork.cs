using topop.Infrastructure.Repository.Interface;

namespace topop.Infrastructure.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IVideoRepository VideoRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
