using MusicPlayer.DataLayer.Entities;

namespace MusicPlayer.ServiceLayer.Services.Interfaces
{
    public interface IPlaylistsService
    {
        Task<IEnumerable<Playlist>> GetPlaylists();
        Task<Playlist> GetPlaylistById(int id);
        Task CreatePlaylist(Playlist playlist);
        Task UpdatePlaylist(Playlist playlist);
        Task DeletePlaylist(int id);
    }
}
