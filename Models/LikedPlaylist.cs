using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApi.Models
{
    [PrimaryKey("PlaylistId", "ProfileId")]
    public class LikedPlaylist
    {
        public int PlaylistId { get; set; }
        [ForeignKey("PlaylistId")]
        public Playlist Playlist { get; set; }
        public string ProfileId { get; set; }
        [ForeignKey("ProfileId")]
        public Profile Profile { get; set; }
    }
}
