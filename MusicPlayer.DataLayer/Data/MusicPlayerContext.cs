using MusicPlayer.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using MusicPlayer.DataLayer.Entities.ConnectorEntities;

namespace MusicPlayer.DataLayer.Data
{
    public class MusicPlayerContext : DbContext
    {
        public MusicPlayerContext(DbContextOptions<MusicPlayerContext> options) : base(options) { }

        public DbSet<Artist> Artists { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Song> Songs { get; set; } = null!;
        public DbSet<Album> Albums { get; set; } = null!;
        public DbSet<Playlist> Playlists { get; set; } = null!;
        public DbSet<AlbumSong> AlbumSongs { get; set; } = null!;
        public DbSet<PlaylistSong> PlaylistSongs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Artist>().HasMany(s => s.Songs).WithOne();
            builder.Entity<Artist>().HasMany(s => s.Albums).WithOne();
            builder.Entity<Client>().HasMany(s => s.Playlists).WithOne();
        }
    }
}
