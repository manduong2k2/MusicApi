using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApi.Models
{
    [PrimaryKey("SongId","ProfileId")]
    public class LikedSong
    {

        public int SongId { get; set; }
        [ForeignKey("SongId")]
        public Song Song { get; set; }

        public string ProfileId { get; set; }
        [ForeignKey("ProfileId")]
        public Profile Profile { get; set; }
    }
}
