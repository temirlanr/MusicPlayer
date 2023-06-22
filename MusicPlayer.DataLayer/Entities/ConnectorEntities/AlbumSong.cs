using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicPlayer.DataLayer.Entities.ConnectorEntities
{
    public class AlbumSong
    {
        [Key]
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int SongId { get; set; }
    }
}
