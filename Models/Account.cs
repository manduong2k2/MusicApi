using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApi.Models
{
    public class Account
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }
        public bool? TypeId { get; set; }
        [ForeignKey("TypeId")]
        public AccountType? AccountType { get; set; }
        public Profile? Profile { get; set; }

        public Account(string id, string password, bool? typeId)
        {
            Id = id;
            Password = password;
            TypeId = typeId;
        }
    }
}
