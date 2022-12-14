using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MultiTracks.API.Models
{
    public partial class MultiTracksDBContext : DbContext
    {
        public MultiTracksDBContext()
        {
        }

        public MultiTracksDBContext(DbContextOptions<MultiTracksDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; } = null!;
        public virtual DbSet<Artist> Artists { get; set; } = null!;
        public virtual DbSet<AssessmentStep> AssessmentSteps { get; set; } = null!;
        public virtual DbSet<Song> Songs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MultiTracksDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("Album");

                entity.Property(e => e.AlbumId).HasColumnName("albumID");

                entity.Property(e => e.ArtistId).HasColumnName("artistID");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dateCreation")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("imageURL");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("Artist");

                entity.Property(e => e.ArtistId).HasColumnName("artistID");

                entity.Property(e => e.Biography)
                    .IsUnicode(false)
                    .HasColumnName("biography");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dateCreation")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.HeroUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("heroURL");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("imageURL");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<AssessmentStep>(entity =>
            {
                entity.HasKey(e => e.StepId)
                    .HasName("PK__Assessme__4E25C23DD17B9F03");

                entity.Property(e => e.StepId).HasColumnName("stepID");

                entity.Property(e => e.Text)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("text");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("Song");

                entity.Property(e => e.SongId).HasColumnName("songID");

                entity.Property(e => e.AlbumId).HasColumnName("albumID");

                entity.Property(e => e.ArtistId).HasColumnName("artistID");

                entity.Property(e => e.Bpm)
                    .HasColumnType("decimal(6, 2)")
                    .HasColumnName("bpm");

                entity.Property(e => e.Chart).HasColumnName("chart");

                entity.Property(e => e.CustomMix).HasColumnName("customMix");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dateCreation")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Multitracks).HasColumnName("multitracks");

                entity.Property(e => e.Patches).HasColumnName("patches");

                entity.Property(e => e.ProPresenter).HasColumnName("proPresenter");

                entity.Property(e => e.RehearsalMix).HasColumnName("rehearsalMix");

                entity.Property(e => e.SongSpecificPatches).HasColumnName("songSpecificPatches");

                entity.Property(e => e.TimeSignature)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("timeSignature");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
