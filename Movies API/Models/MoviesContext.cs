using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Movies_API.Tools;

namespace Movies_API.Models;

public partial class MoviesContext : DbContext
{
    public MoviesContext()
    {
    }

    public MoviesContext(DbContextOptions<MoviesContext> options)
        : base(options)
    {
        try 
        { 
            var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (dbCreator != null) 
            {
                if (!dbCreator.CanConnect()) dbCreator.Create();
                if (!dbCreator.HasTables()) dbCreator.CreateTables();
                Database.EnsureCreated();
              
            }
        
        
        
        }
        catch(Exception ex) 
        {

            Console.WriteLine("Error: " + ex.Message);
        
        
        }



    }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieRating> MovieRatings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.Property(e => e.Genre1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Genre");
            entity.HasData(
                new Genre() { Id = 1, Genre1 = "Horror" },
                new Genre() { Id = 2, Genre1 = "Drama"},
                new Genre() { Id = 3, Genre1 = "Sci-fi" },
                new Genre() { Id = 4, Genre1 = "Thriller" },
                new Genre() { Id = 5, Genre1 = "Action" });
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.Property(e => e.IdAgeRating).HasColumnName("Id_age_rating");
            entity.Property(e => e.IdGenre).HasColumnName("Id_genre");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReleaseDate).HasColumnName("Release_date");

            entity.HasOne(d => d.IdAgeRatingNavigation).WithMany(p => p.Movies)
                .HasForeignKey(d => d.IdAgeRating)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movies_Movie_ratings");

            entity.HasOne(d => d.IdGenreNavigation).WithMany(p => p.Movies)
                .HasForeignKey(d => d.IdGenre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movies_Genres");
            entity.HasData(
                new Movie() { Id = 1, Name = "Alien", IdGenre = 1, IdAgeRating = 4, ReleaseDate = DateOnly.Parse("1979-06-22")  },
                new Movie() { Id = 2, Name = "The Batman", IdGenre = 5, IdAgeRating = 3, ReleaseDate = DateOnly.Parse("2022-03-04") },
                new Movie() { Id = 3, Name = "Mickey 17", IdGenre = 3, IdAgeRating = 4, ReleaseDate = DateOnly.Parse("2025-01-28") }
                );
        });

        modelBuilder.Entity<MovieRating>(entity =>
        {
            entity.ToTable("Movie_ratings");

            entity.Property(e => e.Rating)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.HasData(
                new MovieRating() { Id = 1, Rating = "G"},
                new MovieRating() { Id = 2, Rating = "PG" },
                new MovieRating() { Id = 3, Rating = "PG-13" },
                new MovieRating() { Id = 4, Rating = "R" },
                new MovieRating() { Id = 5, Rating = "NC-17" }
                );
        });



        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Email, "IX_Users_Email").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.HasData(
                new User() { Id = 1, Email = "jrc@gmail.com", Name = "Jancy", Password = Encrypt.GetSHA256("1234") },
                new User() { Id = 2, Email = "jane@gmail.com", Name = "Jane", Password = Encrypt.GetSHA256("qwerty") });
        }           );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
