using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicPlayer.DataLayer.Entities.ConnectorEntities
{
    public class PlaylistSong
    {
        [Key]
        public int Id { get; set; }
        public int PlaylistId { get; set; }
        public int SongId { get; set; }
    }
}
