
using AutoMapper;
using topop.Application.Dtos;
using topop.Domain.Models;
using topop.Infrastructure.Repository.Interface;

namespace topop.Application.Services.Imp
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;

        public VideoService(IVideoRepository videoRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        public async Task<List<GetVideoDto>> GetAllAsync()
        {
            var videos = await _videoRepository.GetAllAsync();
            return _mapper.Map<List<GetVideoDto>>(videos);
        }

        public async Task<GetVideoDto?> GetByIdAsync(int id)
        {
            var video = await _videoRepository.GetByIdAsync(id);
            return video != null ? _mapper.Map<GetVideoDto>(video) : null;
        }

        public async Task<Video> AddAsync(AddVideoDto videoDTO)
        {
            var video = _mapper.Map<Video>(videoDTO);
            await _videoRepository.AddAsync(video);

            return video;
        }

        public async Task UpdateAsync(UpdateVideoDto videoDTO)
        {
            var video = _mapper.Map<Video>(videoDTO);
            await _videoRepository.UpdateAsync(video);
        }

        public async Task DeleteAsync(int id) => await _videoRepository.DeleteAsync(id);

    }
}
