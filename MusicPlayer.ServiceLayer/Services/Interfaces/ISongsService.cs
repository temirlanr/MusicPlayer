using MusicPlayer.DataLayer.Entities;

namespace MusicPlayer.ServiceLayer.Services.Interfaces
{
    public interface ISongsService
    {
        Task<IEnumerable<Song>> GetSongs();
        Task<Song> GetSongById(int id);
        Task CreateSong(Song song);
        Task UpdateSong(Song song);
        Task DeleteSong(int id);
    }
}
