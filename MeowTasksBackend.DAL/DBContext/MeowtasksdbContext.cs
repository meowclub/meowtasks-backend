﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using MeowTasksBackend.Entity;

namespace MeowTasksBackend.DAL.DBContext;

public partial class MeowtasksdbContext : DbContext
{
    public MeowtasksdbContext()
    {
    }

    public MeowtasksdbContext(DbContextOptions<MeowtasksdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MeowProduct> MeowProducts { get; set; }

    public virtual DbSet<MeowTask> MeowTasks { get; set; }

    public virtual DbSet<MeowUser> MeowUsers { get; set; }

    public virtual DbSet<MeowUserBag> MeowUserBags { get; set; }

    public virtual DbSet<MeowUserRole> MeowUserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MeowProduct>(entity =>
        {
            entity.HasKey(e => e.MeowProductId).HasName("PK__meowProd__83DDB4A6F18A8722");

            entity.ToTable("meowProduct");

            entity.Property(e => e.MeowProductId).HasColumnName("meowProductId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("not description")
                .HasColumnName("description");
            entity.Property(e => e.MeowPoints).HasColumnName("meowPoints");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasDefaultValue(1)
                .HasColumnName("type");
            entity.Property(e => e.Uses).HasColumnName("uses");
            entity.Property(e => e.Value)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("value");
        });

        modelBuilder.Entity<MeowTask>(entity =>
        {
            entity.HasKey(e => e.MeowTaskId).HasName("PK__meowTask__226D9A1EE728D2DD");

            entity.ToTable("meowTask");

            entity.HasIndex(e => e.Name, "UQ__meowTask__72E12F1BE3BB26C7").IsUnique();

            entity.Property(e => e.MeowTaskId).HasColumnName("meowTaskId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValue("not description.")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Private)
                .HasDefaultValue(false)
                .HasColumnName("private");
            entity.Property(e => e.Status)
                .HasDefaultValue(0)
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasDefaultValue(0)
                .HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.MeowTasks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__meowTask__userId__5AEE82B9");
        });

        modelBuilder.Entity<MeowUser>(entity =>
        {
            entity.HasKey(e => e.MeowUserId).HasName("PK__meowUser__145BDA98DA9B389E");

            entity.ToTable("meowUser");

            entity.HasIndex(e => e.Nickname, "UQ__meowUser__5CF1C59B9724AAFB").IsUnique();

            entity.Property(e => e.MeowUserId).HasColumnName("meowUserId");
            entity.Property(e => e.Avatar)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("default")
                .HasColumnName("avatar");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("default")
                .HasColumnName("color");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.MeowPoints)
                .HasDefaultValue(0)
                .HasColumnName("meowPoints");
            entity.Property(e => e.Nickname)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("nickname");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PasswordHint)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("passwordHint");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<MeowUserBag>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("meowUserBag");

            entity.Property(e => e.MeowUserId).HasColumnName("meowUserId");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.PurchasedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("purchasedAt");
            entity.Property(e => e.Uses)
                .HasDefaultValue(0)
                .HasColumnName("uses");

            entity.HasOne(d => d.MeowUser).WithMany()
                .HasForeignKey(d => d.MeowUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__meowUserB__meowU__619B8048");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__meowUserB__produ__628FA481");
        });

        modelBuilder.Entity<MeowUserRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__meowUser__CD98462A339673BC");

            entity.ToTable("meowUserRole");

            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Name)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.MeowUserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__meowUserR__userI__5165187F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
