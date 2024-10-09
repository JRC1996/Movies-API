using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Movies_API.Models;

public partial class MoviesContext : DbContext
{
    public MoviesContext()
    {
    }

    public MoviesContext(DbContextOptions<MoviesContext> options)
        : base(options)
    {
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
        });

        modelBuilder.Entity<MovieRating>(entity =>
        {
            entity.ToTable("Movie_ratings");

            entity.Property(e => e.Rating)
                .HasMaxLength(50)
                .IsUnicode(false);
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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
