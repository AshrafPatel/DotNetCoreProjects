using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongList.Models
{
    public class SongContext : DbContext
    {
        public SongContext(DbContextOptions<SongContext> options) : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId=1, Name= "Hip-Hop"},
                new Genre { GenreId=2, Name="Metal"},
                new Genre { GenreId=3, Name="Punk"},
                new Genre { GenreId=4, Name="Techno"}
            );

            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    SongId = 1,
                    Name = "Take Control",
                    Year = 2020,
                    Rating = 5,
                    GenreId = 2
                },
                new Song
                {
                    SongId = 2,
                    Name = "Dr. Stone",
                    Year = 2019,
                    Rating = 4,
                    GenreId = 4
                }
            );
        }
    }
}
