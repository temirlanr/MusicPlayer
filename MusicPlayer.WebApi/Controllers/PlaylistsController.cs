using MusicPlayer.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using MusicPlayer.ServiceLayer.Services.Interfaces;

namespace MusicPlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylistsService _service;

        public PlaylistsController(IPlaylistsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
        {
            try
            {
                return Ok(await _service.GetPlaylists());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Playlist>> GetPlaylist(int id)
        {
            try
            {
                return Ok(await _service.GetPlaylistById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<Playlist>> AddPlaylist([FromBody] Playlist playlist)
        {
            try
            {
                await _service.CreatePlaylist(playlist);
                return CreatedAtAction(nameof(GetPlaylist), new { id = playlist.Id }, playlist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePlaylist([FromBody] Playlist playlist)
        {
            try
            {
                await _service.UpdatePlaylist(playlist);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlaylist(int id)
        {
            try
            {
                await _service.DeletePlaylist(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
