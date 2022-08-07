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
            DotModel d1 = new()
            { 
                Id = 1,
                X = 100,
                Y = 100,
                Radius = 100,
                HEXColor = "#ff0000"
            };
            DotModel d2 = new()
            {
                Id = 2,
                X = 400,
                Y = 200,
                Radius = 50,
                HEXColor = "#0000ff"
            };
            CommentModel c1 = new()
            {
                Id = 1,
                Text = "Comment 1",
                HEXColor = "#ff0000",
                DotModelId = 1,
            };
            CommentModel c2 = new()
            {
                Id = 2,
                Text = "Comment 2",
                HEXColor = "#ff0000",
                DotModelId = 2,
            };
            CommentModel c3 = new()
            {
                Id = 3,
                Text = "Comment 3",
                HEXColor = "#0000ff",
                DotModelId = 1,
            };
            CommentModel c4 = new()
            {
                Id = 4,
                Text = "Comment 4wwwwwwwwwwwwwwwwwwwwwwwww",
                HEXColor = "#0000ff",
                DotModelId = 2,
            };

            modelBuilder.Entity<DotModel>().HasData(d1, d2);
            modelBuilder.Entity<CommentModel>().HasData(c1,c2,c3,c4);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}