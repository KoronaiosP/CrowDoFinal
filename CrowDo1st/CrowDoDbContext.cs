using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Text;

namespace CrowDo1st
{
    public class CrowDoDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Photos> Photos { get; set; }
        public DbSet<Videos> Videos { get; set; }
        
        public DbSet<ProjectProfilePage> ProjectProfilePage { get; set; }
        public DbSet<UserProject> UserProject { get; set; }
        public DbSet<ProjectCategory> ProjectCategory { get; set; }
        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=localhost;Database=CrowDoDb; Trusted_Connection = True; ConnectRetryCount = 0;",
                b => b.EnableRetryOnFailure());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<ProjectProfilePage>();
            modelBuilder.Entity<Category>();
          
            modelBuilder.Entity<Photos>();
            modelBuilder.Entity<Videos>();
           
            modelBuilder.Entity<User>();
            modelBuilder.Entity<UserProject>()
                .HasKey(bp => new { bp.UserId, bp.ProjectProfilePageId });
            modelBuilder.Entity<ProjectCategory>()
                .HasKey(bp => new { bp.ProjectProfilePageId, bp.CategoryId });





        }
    }
}

