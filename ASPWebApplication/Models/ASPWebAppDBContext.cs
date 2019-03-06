using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPWebApplication.Models
{
    public partial class ASPWebAppDBContext : DbContext
    {
        public ASPWebAppDBContext()
        {
        }

        public ASPWebAppDBContext(DbContextOptions<ASPWebAppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=STEELPHANTOM\\SQLEXPRESS;Database=ASPWebAppDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JobRole)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.TaskId);

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.Task)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TaskDate).HasColumnType("datetime");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__Tasks__PersonID__2D27B809");
            });
        }
    }
}
