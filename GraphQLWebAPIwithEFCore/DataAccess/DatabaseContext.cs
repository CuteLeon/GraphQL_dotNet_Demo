using GraphQLWebAPIwithEFCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQLWebAPIwithEFCore.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Property> Properties { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>().HasKey(x => x.ID);
            modelBuilder.Entity<Property>().HasMany(x => x.Payments);
            modelBuilder.Entity<Payment>().HasKey(x => x.ID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
