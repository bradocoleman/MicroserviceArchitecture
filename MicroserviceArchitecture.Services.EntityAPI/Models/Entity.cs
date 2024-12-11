using System.ComponentModel.DataAnnotations;

namespace MicroserviceArchitecture.Services.EntityAPI.Models
{
    public class Entity
    {
        [Key]
        public int EntityId { get; set; }
        [Required]
        public string EntityCode { get; set; }
        [Required]
        public int Discount { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
    }
}
