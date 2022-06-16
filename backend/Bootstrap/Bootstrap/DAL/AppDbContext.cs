using Bootstrap.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Bootstrap.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.Entity<Settings>()
                .HasIndex(u => u.Key)
                .IsUnique();
            base.OnModelCreating(Builder);
        }

        public DbSet<Caption> captions { get; set; }

        public DbSet<Card> cards { get; set; }

        public DbSet<About> abouts { get; set; }

        public DbSet<Settings> settings { get; set; }
    }
}
