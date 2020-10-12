using System;
using Microsoft.EntityFrameworkCore;

namespace DarmexAgroTest.Models
{
    public partial class DarmexAgroDbContext : DbContext
    {
        public DarmexAgroDbContext()
        {
        }

        public DarmexAgroDbContext(DbContextOptions<DarmexAgroDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Costumer> Costumers { get; set; }
        public virtual DbSet<Produk> Produks { get; set; }
        public virtual DbSet<ProdukDetail> ProdukDetails { get; set; }
        public virtual DbSet<Transaksi> Transaksis { get; set; }
        public virtual DbSet<TransaksiDetail> TransaksiDetails { get; set; }
        public virtual DbSet<VProdukDetail> VProdukDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;database=darmexagro_db;uid=root;password=root");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("table_user");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Username)
                    .HasColumnName("user_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Costumer>(entity =>
            {
                entity.ToTable("table_costumer");

                entity.Property(e => e.CostumerId)
                    .HasColumnName("costumer_id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.CostumerName)
                    .HasColumnName("costumer_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Produk>(entity =>
            {
                entity.ToTable("table_produk");

                entity.Property(e => e.ProdukId)
                    .HasColumnName("produk_id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProdukName)
                    .HasColumnName("produk_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProdukDetail>(entity =>
            {
                entity.ToTable("table_produk_detail");

                entity.Property(e => e.ProdukDetailId)
                    .HasColumnName("produk_detail_id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProdukId)
                    .HasColumnName("produk_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProdukDetailName)
                    .HasColumnName("produk_detail_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PricePerItem)
                    .HasColumnName("price_per_item")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.ToTable("table_transaksi");

                entity.Property(e => e.TransaksiId)
                    .HasColumnName("transaksi_id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.TransaksiDate)
                    .HasColumnName("transaksi_date")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CostumerId)
                    .HasColumnName("costumer_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CostumerName)
                    .HasColumnName("costumer_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalPurchase)
                    .HasColumnName("total_purchase")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TotalPayment)
                    .HasColumnName("total_payment")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TransaksiDetail>(entity =>
            {
                entity.ToTable("table_transaksi_detail");

                entity.Property(e => e.TransaksiDetailId)
                    .HasColumnName("transaksi_detail_id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.TransaksiId)
                    .HasColumnName("transaksi_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProdukDetailId)
                    .HasColumnName("produk_detail_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProdukDetailName)
                    .HasColumnName("produk_detail_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberOfItems)
                    .HasColumnName("number_of_items")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PricePerItem)
                    .HasColumnName("price_per_item")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("total_price")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VProdukDetail>(entity =>
            {
                entity.ToTable("view_produk_detail");

                entity.Property(e => e.ProdukDetailId)
                    .HasColumnName("produk_detail_id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProdukId)
                    .HasColumnName("produk_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProdukName)
                    .HasColumnName("produk_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProdukDetailName)
                    .HasColumnName("produk_detail_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PricePerItem)
                    .HasColumnName("price_per_item")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
        }
    }
}