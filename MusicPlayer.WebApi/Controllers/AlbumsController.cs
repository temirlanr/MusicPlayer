using Microsoft.AspNetCore.Mvc;
using MusicPlayer.DataLayer.Entities;
using MusicPlayer.ServiceLayer.Services.Interfaces;

namespace MusicPlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumsService _service;

        public AlbumsController(IAlbumsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            try
            {
                return Ok(await _service.GetAlbums());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            try
            {
                return Ok(await _service.GetAlbumById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<Album>> AddAlbum([FromBody] Album album)
        {
            try
            {
                await _service.CreateAlbum(album);
                return CreatedAtAction(nameof(GetAlbum), new { id = album.Id }, album);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAlbum([FromBody] Album album)
        {
            try
            {
                await _service.UpdateAlbum(album);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAlbum(int id)
        {
            try
            {
                await _service.DeleteAlbum(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
