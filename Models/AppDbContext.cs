using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.Models
{
    // You can Change DbContext to your desired name
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        #region DbSets
        // Add your DbSets here
        #endregion

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Roles Seed
            modelBuilder.Entity<IdentityRole>(entity =>
            {
                // Add Admin Role
                entity.HasData(new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });

                // Add User Role
                entity.HasData(new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                });

                // Add SuperAdmin Role
                entity.HasData(new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN"
                });
            });
            #endregion

            // Add your model configurations here
        }
    }
}
