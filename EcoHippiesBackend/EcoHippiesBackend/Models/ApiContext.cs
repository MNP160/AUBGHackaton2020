using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoHippiesBackend.Models
{
    public class ApiContext :DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Replies> Replies { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Comments> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
             .HasMany(c => c.Comments)
             .WithOne(u => u.User)
             .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Users>()
             .HasMany(r => r.Replies)
             .WithOne(u => u.User)
             .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Users>()
             .HasMany(l => l.Locations)
             .WithOne(u => u.User)
             .HasForeignKey(l => l.UserId);

            modelBuilder.Entity<Comments>()
             .HasMany(r => r.Replies)
             .WithOne(c => c.Comment)
             .HasForeignKey(r => r.CommentId);

            modelBuilder.Entity<Locations>()
                .HasOne(l => l.Post)
                .WithOne(p => p.Location)
                .HasForeignKey<Posts>(p => p.LocationId);

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
