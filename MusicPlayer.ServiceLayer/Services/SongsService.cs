using MusicPlayer.DataLayer.Data;
using MusicPlayer.DataLayer.Entities;
using MusicPlayer.ServiceLayer.Services.Interfaces;

namespace MusicPlayer.ServiceLayer.Services
{
    public class SongsService : ISongsService
    {
        private readonly MusicPlayerContext _context;

        public SongsService(MusicPlayerContext context)
        {
            _context = context;
        }

        public async Task CreateSong(Song song)
        {
            if(song == null) throw new ArgumentNullException(nameof(song));

            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSong(int id)
        {
            var song = _context.Songs.FirstOrDefault(s => s.Id == id) ?? throw new NullReferenceException($"Song with id {id} not found.");

            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
        }

        public async Task<Song> GetSongById(int id)
        {
            var song = _context.Songs.FirstOrDefault(s => s.Id == id) ?? throw new NullReferenceException($"Song with id {id} not found.");

            return song;
        }

        public async Task<IEnumerable<Song>> GetSongs()
        {
            return _context.Songs.AsEnumerable();
        }

        public async Task UpdateSong(Song song)
        {
            _context.Songs.Update(song);
            await _context.SaveChangesAsync();
        }
    }
}
