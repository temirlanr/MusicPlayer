using MusicPlayer.DataLayer.Entities.Base;

namespace MusicPlayer.DataLayer.Entities
{
    public class Artist : BaseEntity
    {
        public IEnumerable<Song>? Songs { get; set; }
        public IEnumerable<Album>? Albums { get; set; }
    }
}
