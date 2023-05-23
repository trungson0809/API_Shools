using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI_QuanLyHocSinh.Context
{
    public partial class db_schoolsContext : DbContext
    {
        public db_schoolsContext()
        {
        }

        public db_schoolsContext(DbContextOptions<db_schoolsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Ranking> Rankings { get; set; } = null!;
        public virtual DbSet<Result> Results { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-8OESDIPL;Initial Catalog=db_schools;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Mark).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Course_Student");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Course_Subject");
            });

            modelBuilder.Entity<Ranking>(entity =>
            {
                entity.HasKey(e => e.RankId);

                entity.ToTable("Ranking");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(e => new { e.ResultId, e.StudentId });

                entity.ToTable("Result");

                entity.Property(e => e.ResultId).ValueGeneratedOnAdd();

                entity.Property(e => e.Gpa)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("GPA");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.RankId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Result_Ranking");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Result_Student");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Student_Class");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
