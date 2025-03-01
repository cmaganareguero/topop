
using topop.Application.Dtos;
using topop.Domain.Models;

namespace topop.Application.Services
{
    public interface IVideoService
    {
        Task<List<GetVideoDto>> GetAllAsync();
        Task<GetVideoDto?> GetByIdAsync(int id);
        Task<Video> AddAsync(AddVideoDto videoDTO);
        Task UpdateAsync(UpdateVideoDto videoDTO);
        Task DeleteAsync(int id);
    }
}
