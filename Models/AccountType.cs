using System.ComponentModel.DataAnnotations;

namespace MusicApi.Models
{
    public class AccountType
    {
        [Key]
        public bool Id { get; set; }
        [Required]
        [StringLength(10)]
        public string? Name { get; set; }
        public virtual ICollection<Account>? Accounts { get; set; }
    }
}
