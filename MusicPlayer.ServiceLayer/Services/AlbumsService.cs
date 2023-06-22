using MusicPlayer.DataLayer.Data;
using MusicPlayer.DataLayer.Entities;
using MusicPlayer.ServiceLayer.Services.Interfaces;

namespace MusicPlayer.ServiceLayer.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly MusicPlayerContext _context;

        public AlbumsService(MusicPlayerContext context)
        {
            _context = context;
        }

        public async Task CreateAlbum(Album album)
        {
            if (album == null) throw new ArgumentNullException(nameof(album));

            _context.Albums.Add(album);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAlbum(int id)
        {
            var album = _context.Albums.FirstOrDefault(s => s.Id == id) ?? throw new NullReferenceException($"Album with id {id} not found.");

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
        }

        public async Task<Album> GetAlbumById(int id)
        {
            var album = _context.Albums.FirstOrDefault(s => s.Id == id) ?? throw new NullReferenceException($"Album with id {id} not found.");

            return album;
        }

        public async Task<IEnumerable<Album>> GetAlbums()
        {
            return _context.Albums.AsEnumerable();
        }

        public async Task UpdateAlbum(Album album)
        {
            _context.Albums.Update(album);
            await _context.SaveChangesAsync();
        }
    }
}
