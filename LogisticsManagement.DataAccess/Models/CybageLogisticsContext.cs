using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagement.DataAccess.Models;

public partial class CybageLogisticsContext : DbContext
{
    public CybageLogisticsContext()
    {
    }

    public CybageLogisticsContext(DbContextOptions<CybageLogisticsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<ResourceMapping> ResourceMappings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<ShipmentDetail> ShipmentDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=CybageLogistics;Trusted_Connection=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inventor__3214EC07540AC907");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductDescription).IsUnicode(false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventori__Wareh__1367E606");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC070B7DF171");

            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__userId__21B6055D");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC072B3461FE");

            entity.Property(e => e.OrderStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Inventory).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.InventoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Inven__25869641");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__24927208");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resource__3214EC07CEB759BE");

            entity.Property(e => e.IsAvailable).HasDefaultValue(true);

            entity.HasOne(d => d.ResourceNavigation).WithMany(p => p.Resources)
                .HasForeignKey(d => d.ResourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Resources__Resou__2C3393D0");
        });

        modelBuilder.Entity<ResourceMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resource__3214EC075A8FB5AE");

            entity.ToTable("ResourceMapping");

            entity.HasOne(d => d.Manager).WithMany(p => p.ResourceMappings)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ResourceM__Manag__30F848ED");

            entity.HasOne(d => d.OrderDetails).WithMany(p => p.ResourceMappings)
                .HasForeignKey(d => d.OrderDetailsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ResourceM__Order__300424B4");

            entity.HasOne(d => d.Resource).WithMany(p => p.ResourceMappings)
                .HasForeignKey(d => d.ResourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ResourceM__Resou__2F10007B");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07C3F18F54");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ShipmentDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shipment__3214EC0742F02B3E");

            entity.Property(e => e.Destination)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.ExpectedArrivalTime).HasColumnType("datetime");
            entity.Property(e => e.Origin)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.OrderDetails).WithMany(p => p.ShipmentDetails)
                .HasForeignKey(d => d.OrderDetailsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShipmentD__Order__286302EC");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07475CAB33");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053432493A24").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleId__1920BF5C");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserDeta__3214EC0732307940");

            entity.Property(e => e.IsApproved).HasDefaultValue(false);
            entity.Property(e => e.LicenseNumber)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.ShippingAddress)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.VehicleNumber)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.VehicleType)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.WarehouseId).HasDefaultValue(1);

            entity.HasOne(d => d.User).WithMany(p => p.UserDetails)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserDetai__UserI__3B75D760");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.UserDetails)
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK__UserDetai__Wareh__3C69FB99");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Warehous__3214EC072861DB10");

            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
