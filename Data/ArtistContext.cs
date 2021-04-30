using MavelArtist.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MavelArtist.Data
{
    public class ArtistContext:DbContext
    {
        public ArtistContext(DbContextOptions<ArtistContext> options):base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .HasKey(k => k.ArtistId);

            modelBuilder.Entity<MavelCharacter>()
                .HasKey(k => k.CharacterId);

            modelBuilder.Entity<Movies>()
                .HasKey(k => k.MovieId);


            // 1->many relationship
            modelBuilder.Entity<Movies>()
                 .HasOne(a => a.Artist)
                 .WithMany(m => m.Movies)
                 .HasForeignKey(f => f.ArtistId);
            // 1->1
            modelBuilder.Entity<Artist>()
                 .HasOne(mc => mc.MavelCharacter)
                 .WithOne(a => a.Artist)
                 .HasForeignKey<MavelCharacter>(f => f.ArtistId);
                 

        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<MavelCharacter> MavelCharacters { get; set; }
        public DbSet<Movies> Movies { get; set; }
    }
}
