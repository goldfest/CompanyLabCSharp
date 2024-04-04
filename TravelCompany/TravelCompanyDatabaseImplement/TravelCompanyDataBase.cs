using TravelCompanyDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace TravelCompanyDatabaseImplement
{
    public class TravelCompanyDataBase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder
optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-D5A5OOG\GOLDFEST;Initial Catalog=TravelCompanyHard;Integrated Security=True;MultipleActiveResultSets=True;;TrustServerCertificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Models.Component> Components { set; get; }
        public virtual DbSet<Travel> Travels { set; get; }
        public virtual DbSet<TravelComponent> TravelComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<ShopTravels> ShopTravels { get; set; }

    }
}
