using System.ComponentModel.DataAnnotations;

namespace MusicApi.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? cardNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? CVC { get; set; }
    }
}
