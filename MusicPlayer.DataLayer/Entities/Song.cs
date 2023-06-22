using MusicPlayer.DataLayer.Entities.Base;

namespace MusicPlayer.DataLayer.Entities
{
    public class Song : BaseEntity
    {
        public string Genre { get; set; } = null!;
        public string? FileUrl { get; set; }
        public long? FileLength { get; set; }
        public int ArtistId { get; set; }
    }
}
