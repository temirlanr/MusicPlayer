using MusicPlayer.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using MusicPlayer.ServiceLayer.Services.Interfaces;
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace MusicPlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongsService _service;

        public SongsController(ISongsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            try
            {
                return Ok(await _service.GetSongs());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
            try
            {
                return Ok(await _service.GetSongById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult> StreamSong(int id)
        {
            try
            {
                var song = await _service.GetSongById(id) ?? throw new NullReferenceException("Song not found.");

                if (song.FileUrl == null || song.FileLength == null)
                    throw new NullReferenceException("File path or file length is null.");

                Response.Headers.Add("Content-Type", "audio/mpeg");
                Response.Headers.Add("Content-Length", song.FileLength.ToString());

                using (var stream = new FileStream(song.FileUrl, FileMode.Open))
                {
                    await stream.CopyToAsync(Response.Body);
                }

                await Response.Body.FlushAsync();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Song>> AddSong([FromBody]Song song, IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file uploaded.");
                }

                // TODO: Validate the file (e.g., file size, file type)

                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine("songs", uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                song.FileUrl = filePath;
                song.FileLength = file.Length;

                await _service.CreateSong(song);
                return CreatedAtAction(nameof(GetSong), new { id = song.Id }, song);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSong([FromBody]Song song)
        {
            try
            {
                await _service.UpdateSong(song);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSong(int id)
        {
            try
            {
                await _service.DeleteSong(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
