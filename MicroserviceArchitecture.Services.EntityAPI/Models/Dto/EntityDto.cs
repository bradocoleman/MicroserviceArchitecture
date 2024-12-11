namespace MicroserviceArchitecture.Services.EntityAPI.Models.Dto
{
    public class EntityDto
    {
        public int EntityId { get; set; }
        public string EntityCode { get; set; }
        public int Discount { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
    }
}
