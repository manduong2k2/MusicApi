using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApi.Models
{
    public class Notification
    {
        [Key]
        public string Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set;}
        [ForeignKey("Id")]
        public Profile? Profile { get; set; }
    }
}
