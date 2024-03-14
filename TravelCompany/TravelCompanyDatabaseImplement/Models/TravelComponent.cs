using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyDatabaseImplement.Models
{
    public class TravelComponent
    {
        public int Id { get; set; }
        [Required]
        public int TravelId { get; set; }
        [Required]
        public int ComponentId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Component Component { get; set; } = new();
        public virtual Travel Travel { get; set; } = new();
    }
}
