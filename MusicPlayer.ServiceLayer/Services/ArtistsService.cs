using MusicPlayer.DataLayer.Data;
using MusicPlayer.DataLayer.Entities;
using MusicPlayer.ServiceLayer.Services.Interfaces;

namespace MusicPlayer.ServiceLayer.Services
{
    public class ArtistsService : IArtistsService
    {
        private readonly MusicPlayerContext _context;

        public ArtistsService(MusicPlayerContext context)
        {
            _context = context;
        }

        public async Task CreateArtist(Artist artist)
        {
            if (artist == null) throw new ArgumentNullException(nameof(artist));

            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArtist(int id)
        {
            var artist = _context.Artists.FirstOrDefault(s => s.Id == id) ?? throw new NullReferenceException($"Artist with id {id} not found.");

            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
        }

        public async Task<Artist> GetArtistById(int id)
        {
            var artist = _context.Artists.FirstOrDefault(s => s.Id == id) ?? throw new NullReferenceException($"Artist with id {id} not found.");

            return artist;
        }

        public async Task<IEnumerable<Artist>> GetArtists()
        {
            return _context.Artists.AsEnumerable();
        }

        public async Task UpdateArtist(Artist artist)
        {
            _context.Artists.Update(artist);
            await _context.SaveChangesAsync();
        }
    }
}
