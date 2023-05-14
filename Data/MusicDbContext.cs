using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MusicApi.Models;

namespace MusicApi.Data
{
    public class MusicDbContext : DbContext
    {
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<LikedSong> LikedSongs { get; set; }
        public DbSet<LikedPlaylist> LikedPlaylists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options)
        {
        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();
            var connectionString = configuration.GetConnectionString("MusicDb");
            optionsBuilder.UseSqlServer(connectionString);
        }*/
    }
}
