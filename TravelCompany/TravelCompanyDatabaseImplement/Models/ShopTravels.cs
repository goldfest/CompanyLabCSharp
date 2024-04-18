using System.ComponentModel.DataAnnotations;

namespace TravelCompanyDatabaseImplement.Models
{
    public class ShopTravels
    {
        public int Id { get; set; }

        [Required]
        public int TravelId { get; set; }

        [Required]
        public int ShopId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Shop Shop { get; set; } = new();

        public virtual Travel Travel { get; set; } = new();
    }
}
