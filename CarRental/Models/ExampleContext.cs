using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarRental.Models
{
    public partial class ExampleContext : DbContext
    {
        public ExampleContext()
        {
        }

        public ExampleContext(DbContextOptions<ExampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<CarOrder> CarOrder { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Samuel\\Documents\\CarRentalDBEx.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.RegNr)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.YearModel)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<CarOrder>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.CarId })
                    .HasName("PK__CarOrder__351A588D6A8E1C43");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.CarOrder)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CarOrder__CarId__2B3F6F97");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.CarOrder)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CarOrder__OrderI__2A4B4B5E");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.PersonNr)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNr)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PostalCode)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__CustomerI__276EDEB3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
