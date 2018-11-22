using Microsoft.EntityFrameworkCore;
using SimpleAdmin.Data.Abstractions;
using SimpleAdmin.Data.Entities;
using SimpleAdmin.Data.Extensions;

namespace SimpleAdmin.Data
{
    public class SimpleAdminContext : DbContext, IDbContext
    {
        public SimpleAdminContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.RemovePluralizingTableNameConvention();
        }
    }
}
