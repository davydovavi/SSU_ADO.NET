using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSU_ThreeLayer.Entities
{
    public partial class AppContext: DbContext
    {
        public AppContext()
            :base("name=AppConnection")
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<TypeOfShop> TypeOfShops { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>()
                .HasMany(c => c.UserList)
                .WithMany(c => c.ShopList)
                .Map(m =>
                {
                     m.ToTable("UserOfShop");
                     m.MapLeftKey("IdShop");
                     m.MapRightKey("IdUser");
                });

            modelBuilder.Entity<Shop>()
                .HasMany(p => p.Ratings)
                .WithRequired(p => p.Shop)
                .HasForeignKey(s => s.IdShop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
               .HasMany(p => p.Ratings)
               .WithRequired(p => p.User)
               .HasForeignKey(s => s.IdUser)
               .WillCascadeOnDelete(false);

        }
    }
}
