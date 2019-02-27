using Ass1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ass1.Data
{
    public class BoatContext : IdentityDbContext<IdentityUser>
    {
        public BoatContext(DbContextOptions<BoatContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region "Seed Data"

            builder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "User", NormalizedName = "USER" }
            );

            #endregion
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Boat> Boats { get; set; }

    }
}
