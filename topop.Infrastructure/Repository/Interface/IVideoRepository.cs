﻿using topop.Domain.Models;

namespace topop.Infrastructure.Repository.Interface
{
    public interface IVideoRepository {

        Task<List<Video>> GetAllAsync();
        Task<Video?> GetByIdAsync(int id);
        Task AddAsync(Video video);
        Task UpdateAsync(Video video);
        Task DeleteAsync(int id);

    }
}
 