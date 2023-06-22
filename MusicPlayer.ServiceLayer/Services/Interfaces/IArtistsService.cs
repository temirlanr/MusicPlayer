using MusicPlayer.DataLayer.Entities;

namespace MusicPlayer.ServiceLayer.Services.Interfaces
{
    public interface IArtistsService
    {
        Task<IEnumerable<Artist>> GetArtists();
        Task<Artist> GetArtistById(int id);
        Task CreateArtist(Artist artist);
        Task UpdateArtist(Artist artist);
        Task DeleteArtist(int id);
    }
}
