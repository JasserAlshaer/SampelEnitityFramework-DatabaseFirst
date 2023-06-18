using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SampelEnitityFramework_DatabaseFirst.Models
{
    public partial class StudendTableContext : DbContext
    {
        public StudendTableContext()
        {
        }

        public StudendTableContext(DbContextOptions<StudendTableContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentCorse> StudentCorses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=JASSER\\SQLEXPRESS;Database=StudendTable;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Arabic_CI_AS");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("Login");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<StudentCorse>(entity =>
            {
                entity.ToTable("studentCorse");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.RegisterAt).HasColumnType("datetime");

                entity.Property(e => e.StudentId).HasColumnName("studentID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentCorses)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_for_");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentCorses)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_for_studen");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
