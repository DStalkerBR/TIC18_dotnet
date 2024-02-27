using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.Movie> Movie { get; set; } = default!;

        public DbSet<MvcMovie.Models.User> User { get; set; } = default!;

        public DbSet<MvcMovie.Models.Artist> Artist { get; set; } = default!;

        public DbSet<MvcMovie.Models.Studio> Studio { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MvcMovie.Models.Movie>().ToTable("Movie");
            modelBuilder.Entity<MvcMovie.Models.User>().ToTable("User");
            modelBuilder.Entity<MvcMovie.Models.Artist>().ToTable("Artist");
            modelBuilder.Entity<MvcMovie.Models.Studio>().ToTable("Studio");

            modelBuilder.Entity<MvcMovie.Models.Movie>()
                .HasOne(m => m.Studio)
                .WithMany(s => s.Movies)
                .HasForeignKey(m => m.StudioId);

            modelBuilder.Entity<MvcMovie.Models.Movie>()
                .HasMany(m => m.Artists)
                .WithMany(a => a.Movies);
        }
    }
}
