using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApi.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        
        public string? Url { get; set; }
        public string? ProfileId { get; set; }
        [ForeignKey("ProfileId")]
        public Profile? Profile { get; set; }
        public virtual ICollection<LikedSong> LikedProfiles { get; set; }
        public virtual ICollection<Playlist>? Playlists { get; set; }
        public virtual ICollection<Category> Category { get; set; }
    }
}
