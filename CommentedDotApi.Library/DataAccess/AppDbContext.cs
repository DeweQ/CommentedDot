using CommentedDotApi.Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentedDotApi.Library.DataAccess
{
    public class AppDbContext : DbContext
    {

        public DbSet<DotModel> Dots { get; set; } = null!;
        public DbSet<CommentModel> Comments {get;set;} =null!;

        public AppDbContext( DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DotModel>().HasMany(dm=> dm.Comments).WithOne().OnDelete(DeleteBehavior.SetNull);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}