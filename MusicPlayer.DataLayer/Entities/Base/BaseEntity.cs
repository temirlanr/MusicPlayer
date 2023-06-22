using System.ComponentModel.DataAnnotations;

namespace MusicPlayer.DataLayer.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
    }
}
