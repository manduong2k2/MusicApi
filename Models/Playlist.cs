using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApi.Models
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ProfileId { get; set; }
        [ForeignKey("ProfileId")]
        public Profile? Profile { get; set; }
        public virtual ICollection<LikedPlaylist> LikedProfiles { get; set; }
        public virtual ICollection<Song>? Songs { get; set;}
    }
}
