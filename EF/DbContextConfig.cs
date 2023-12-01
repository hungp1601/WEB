using System;
using Microsoft.EntityFrameworkCore;
using NHNT.Constants;
using NHNT.Models;

namespace NHNT.EF
{
    public class DbContextConfig : DbContext
    {
        public DbContextConfig(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<DepartmentGroup> DepartmentGroups { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("Users");
                e.HasKey(u => u.Id);
                e.Property(e => e.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                e.Property(u => u.Username).HasColumnName("Username").HasMaxLength(100).IsRequired();
                e.HasIndex(u => u.Username).IsUnique();
                e.Property(u => u.Email).HasColumnName("Email").HasMaxLength(150).IsRequired();
                e.HasIndex(u => u.Email).IsUnique();
                e.Property(u => u.Password).HasColumnName("Password").HasMaxLength(255).IsRequired();
                e.HasMany(u => u.UserRoles).WithOne(navigationExpression: ur => ur.User).HasForeignKey(ur => ur.UserId);
                e.Property(u => u.FullName).HasColumnName("FullName").HasMaxLength(255);
                e.HasIndex(u => u.Phone).IsUnique();
                e.Property(u => u.Phone).HasColumnName("Phone").HasMaxLength(11);
                e.Property(u => u.Gender).HasColumnName("Gender").HasConversion<int>().HasDefaultValue(Gender.MALE);
                e.Property(u => u.Birthday).HasColumnName("Birthday");
                e.Property(u => u.IsDisabled).HasColumnName("IsDisabled").HasDefaultValue(0);
                e.Property(u => u.CreatedAt).HasColumnName("CreatedAt").HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
                e.Property(u => u.UpdatedAt).HasColumnName("UpdatedAt").HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();
                e.HasMany(u => u.Departments).WithOne(d => d.User).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Role>(e =>
            {
                e.ToTable("Roles");
                e.HasKey(r => r.Id);
                e.Property(r => r.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                e.Property(r => r.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
                e.HasIndex(r => r.Name).IsUnique();
                e.Property(r => r.Description).HasColumnName("Description").HasMaxLength(300);
                e.HasMany(r => r.UserRoles).WithOne(ur => ur.Role).HasForeignKey(ur => ur.RoleId);
            });

            modelBuilder.Entity<UserRole>(e =>
            {
                e.ToTable("UserRoles");
                e.HasKey(ur => new { ur.RoleId, ur.UserId });
                e.Property(ur => ur.UserId).HasColumnName("UserId");
                e.Property(ur => ur.RoleId).HasColumnName("RoleId");
                e.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);
                e.HasOne(ur => ur.Role).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.RoleId);
            });

            modelBuilder.Entity<RefreshToken>(e =>
            {
                e.ToTable("RefreshTokens");
                e.HasKey(rf => rf.Id);
                e.Property(rf => rf.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                e.Property(rf => rf.UserId).HasColumnName("UserId");
                e.HasOne(rf => rf.User).WithMany().HasForeignKey(rf => rf.UserId).IsRequired();
                e.Property(rf => rf.Value).HasColumnName("Value").IsRequired().HasMaxLength(255);
                e.Property(rf => rf.JwtId).HasColumnName("JwtId").IsRequired().HasMaxLength(255);
                e.Property(rf => rf.IsUsed).HasColumnName("IsUsed").HasDefaultValue(true);
                e.Property(rf => rf.IsRevoked).HasColumnName("IsRevoked").HasDefaultValue(true);
                e.Property(rf => rf.IssuedAt).HasColumnName("IssuedAt").IsRequired();
                e.Property(rf => rf.ExpiredAt).HasColumnName("ExpiredAt").IsRequired();
            });

            modelBuilder.Entity<DepartmentGroup>(e =>
            {
                e.ToTable("DepartmentGroups");
                e.HasKey(dg => dg.Id);
                e.Property(dg => dg.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                e.Property(dg => dg.Name).HasColumnName("Name").HasMaxLength(255).IsRequired();
                e.Property(propertyExpression: dg => dg.Description).HasColumnName("Description").HasMaxLength(maxLength: 1000);
                e.HasMany(dg => dg.Departments).WithOne(d => d.Group).HasForeignKey(d => d.GroupId);
            });

            modelBuilder.Entity<Department>(e =>
            {
                e.ToTable("Department");
                e.HasKey(d => d.Id);
                e.Property(d => d.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                e.Property(d => d.Address).HasColumnName("Address").HasMaxLength(200).IsRequired();
                e.Property(d => d.Price).HasColumnName("Price").HasColumnType("decimal(16, 3)").HasConversion(p => Math.Round(p, 2), p => p).IsRequired();
                e.Property(d => d.Acreage).HasColumnName("Acreage").IsRequired().HasColumnType("decimal(16, 2)").HasConversion(ra => Math.Round(ra, 2), ra => ra);
                e.Property(d => d.Status).HasColumnName("Status").HasConversion<int>().HasDefaultValue(DepartmentStatus.PENDING);
                e.Property(propertyExpression: d => d.Description).HasColumnName("Description").HasMaxLength(1000);
                e.Property(d => d.IsAvailable).HasColumnName("IsAvailable").HasDefaultValue(true);
                e.Property(d => d.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
                e.Property(d => d.UpdatedAt).HasColumnName("UpdatedAt").HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();
                e.Property(d => d.UserId).HasColumnName("UserId");
                e.HasOne(d => d.User).WithMany(u => u.Departments).HasForeignKey(d => d.UserId).IsRequired();
                e.HasOne(d => d.Group).WithMany(dg => dg.Departments).HasForeignKey(d => d.GroupId).IsRequired();
                e.Property(d => d.GroupId).HasColumnName("GroupId");
                e.HasMany(d => d.Images).WithOne(i => i.Department).HasForeignKey(i => i.DepartmentId);
            });

            modelBuilder.Entity<Image>(e =>
            {
                e.ToTable("Images");
                e.HasKey(i => i.Id);
                e.Property(i => i.Id).HasColumnName(name: "Id");
                e.Property(i => i.Path).HasColumnName("Path").HasMaxLength(150).IsRequired();
                e.Property(i => i.CreatedAt).HasColumnName("CreatedAt").HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
                e.Property(i => i.DepartmentId).HasColumnName(name: "DepartmentId");
                e.HasOne(i => i.Department).WithMany(d => d.Images).HasForeignKey(i => i.DepartmentId);
            });
        }

    }
}