using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebNotepad.Models
{
    public partial class WebNotepadDBContext : DbContext
    {
        public WebNotepadDBContext()
        {
        }

        public WebNotepadDBContext(DbContextOptions<WebNotepadDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<NoteKey> NoteKeys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=WebNotepadDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PK__Note__79B5C94C046345B0");

                entity.ToTable("Note");

                entity.Property(e => e.Version).HasColumnName("version");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("content");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasColumnName("modified");

                entity.Property(e => e.NoteId).HasColumnName("note_id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.NoteNavigation)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.NoteId)
                    .HasConstraintName("FK_NoteKey_Note");
            });

            modelBuilder.Entity<NoteKey>(entity =>
            {
                entity.ToTable("NoteKey");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
