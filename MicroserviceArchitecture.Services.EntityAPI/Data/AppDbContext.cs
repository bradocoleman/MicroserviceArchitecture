using MicroserviceArchitecture.Services.EntityAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceArchitecture.Services.EntityAPI.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }
        public DbSet<Entity> Entitys { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Entity>().HasData(new Entity
            {
                EntityId = 1,
                EntityCode = "10%",
                Discount = 10,
                Price = 100.00,
                DiscountPrice = 90.00
            });
            modelBuilder.Entity<Entity>().HasData(new Entity
            {
                EntityId = 2,
                EntityCode = "20%",
                Discount = 20,
                Price = 100.00,
                DiscountPrice = 80.00
            });

        }
    }
}
