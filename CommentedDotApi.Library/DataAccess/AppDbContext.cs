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

        List<DotModel> Dots { get; set; } = null!;

        public AppDbContext( DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommentModel>();
        }
    }
}