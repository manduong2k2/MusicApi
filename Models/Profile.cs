using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApi.Models
{
    public class Profile
    {
        [Key]
        public string Id { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        [StringLength(11)]
        public string? PhoneNumber { get; set; }
        [ForeignKey("Id")]
        public Account? Account { get; set; }
        public virtual ICollection<Song>? Songs { get; set; }
        public virtual ICollection<Playlist>? Playlists { get; set; }
        public virtual ICollection<LikedSong> LikedSongs { get; set; }
        public virtual ICollection<LikedPlaylist> LikedPlaylists { get; set; }
        public virtual ICollection<Profile>? Followers { get; set; }
        public virtual ICollection<Profile>? Followees { get; set; }
        public Profile(string id)
        {
            Id = id;
        }
        public Profile() 
        {
        }
    }
}
