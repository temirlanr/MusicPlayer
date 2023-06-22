using MusicPlayer.DataLayer.Entities.Base;

namespace MusicPlayer.DataLayer.Entities
{
    public class Client : BaseEntity
    {
        public IEnumerable<Playlist>? Playlists { get; set; }
    }
}
