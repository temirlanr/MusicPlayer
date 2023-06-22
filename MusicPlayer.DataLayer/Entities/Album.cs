using MusicPlayer.DataLayer.Entities.Base;

namespace MusicPlayer.DataLayer.Entities
{
    public class Album : BaseEntity
    {
        public string? Description { get; set; }
        public int ArtistId { get; set; }
    }
}
