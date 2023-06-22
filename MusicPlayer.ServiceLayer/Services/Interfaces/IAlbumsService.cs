using MusicPlayer.DataLayer.Entities;

namespace MusicPlayer.ServiceLayer.Services.Interfaces
{
    public interface IAlbumsService
    {
        Task<IEnumerable<Album>> GetAlbums();
        Task<Album> GetAlbumById(int id);
        Task CreateAlbum(Album album);
        Task UpdateAlbum(Album album);
        Task DeleteAlbum(int id);
    }
}
