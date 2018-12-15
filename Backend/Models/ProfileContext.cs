using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExamPro.Models
{
    public partial class ProfileContext : DbContext
    {
        public ProfileContext()
        {
        }

        public ProfileContext(DbContextOptions<ProfileContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Profiles> Profiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-QT0O3QL\\SQLEXPRESS;Initial Catalog=Profile;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profiles>(entity =>
            {
                entity.HasKey(e => e.ProCardId);

                entity.Property(e => e.ProCardId)
                    .HasColumnName("ProCardID")
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProLastname)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProStudy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProTel)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
