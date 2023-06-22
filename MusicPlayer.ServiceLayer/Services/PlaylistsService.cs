using MusicPlayer.DataLayer.Data;
using MusicPlayer.DataLayer.Entities;
using MusicPlayer.ServiceLayer.Services.Interfaces;

namespace MusicPlayer.ServiceLayer.Services
{
    public class PlaylistsService : IPlaylistsService
    {
        private readonly MusicPlayerContext _context;

        public PlaylistsService(MusicPlayerContext context)
        {
            _context = context;
        }

        public async Task CreatePlaylist(Playlist playlist)
        {
            if (playlist == null) throw new ArgumentNullException(nameof(playlist));

            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePlaylist(int id)
        {
            var playlist = _context.Playlists.FirstOrDefault(s => s.Id == id) ?? throw new NullReferenceException($"Playlist with id {id} not found.");

            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();
        }

        public async Task<Playlist> GetPlaylistById(int id)
        {
            var playlist = _context.Playlists.FirstOrDefault(s => s.Id == id) ?? throw new NullReferenceException($"Playlist with id {id} not found.");

            return playlist;
        }

        public async Task<IEnumerable<Playlist>> GetPlaylists()
        {
            return _context.Playlists.AsEnumerable();
        }

        public async Task UpdatePlaylist(Playlist playlist)
        {
            _context.Playlists.Update(playlist);
            await _context.SaveChangesAsync();
        }
    }
}
