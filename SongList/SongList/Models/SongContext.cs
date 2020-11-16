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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    SongId = 1,
                    Name = "Take Control",
                    Year = 2020,
                    Rating = 5
                },
                new Song
                {
                    SongId = 2,
                    Name = "Dr. Stone",
                    Year = 2019,
                    Rating = 3
                }
            );
        }
    }
}
