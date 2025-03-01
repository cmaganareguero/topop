using Microsoft.AspNetCore.Mvc;
using topop.Application.Dtos;
using topop.Application.Services;

namespace topop.API.Controllers.Imp
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService _videoService;

        // Constructor con la inyección de dependencias
        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        // GET api/video
        [HttpGet]
        public async Task<ActionResult<List<GetVideoDto>>> GetAll()
        {
            var videos = await _videoService.GetAllAsync();
            return videos == null || !videos.Any() ? NotFound("No videos found.") : Ok(videos);
        }

        // GET api/video/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GetVideoDto>> GetById(int id)
        {
            var video = await _videoService.GetByIdAsync(id);
            return video == null ? NotFound($"Video with id {id} not found.") : Ok(video);
        }

        // POST api/video
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AddVideoDto videoDTO)
        {
            if (videoDTO == null)
            {
                return BadRequest("Invalid video data.");
            }

            var video = await _videoService.AddAsync(videoDTO);

            return CreatedAtAction(nameof(GetById), new { id = video.Id }, videoDTO);
        }

        // PUT api/video/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateVideoDto videoDTO)
        {
            if (videoDTO == null)
            {
                return BadRequest("Invalid video data.");
            }

            var videoToUpdate = await _videoService.GetByIdAsync(id);
            if (videoToUpdate == null)
            {
                return NotFound($"Video with id {id} not found.");
            }

            await _videoService.UpdateAsync(videoDTO);
            return NoContent(); // Indicates the update was successful
        }

        // DELETE api/video/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var videoToDelete = await _videoService.GetByIdAsync(id);
            if (videoToDelete == null)
            {
                return NotFound($"Video with id {id} not found.");
            }

            await _videoService.DeleteAsync(id);
            return NoContent(); // Indicates the deletion was successful

        }
    }
}
