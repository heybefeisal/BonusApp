using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace KonsultApp.Models
{
    public partial class BonusDBContext : DbContext
    {
        public BonusDBContext()
        {
        }

        public BonusDBContext(DbContextOptions<BonusDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bonu> Bonus { get; set; }
        public virtual DbSet<Konsult> Konsults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-696C3J6\\SQLEXPRESS01;Database=BonusDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bonu>(entity =>
            {
                entity.HasKey(e => e.BonusId);

                entity.Property(e => e.BonusId).HasColumnName("BonusID");

                entity.Property(e => e.KonsultId).HasColumnName("KonsultID");

                entity.HasOne(d => d.Konsult)
                    .WithMany(p => p.Bonus)
                    .HasForeignKey(d => d.KonsultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bonus_Konsult");
            });

            modelBuilder.Entity<Konsult>(entity =>
            {
                entity.ToTable("Konsult");

                entity.Property(e => e.KonsultId).HasColumnName("KonsultID");

                entity.Property(e => e.EfterNamn)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ForNamn)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
