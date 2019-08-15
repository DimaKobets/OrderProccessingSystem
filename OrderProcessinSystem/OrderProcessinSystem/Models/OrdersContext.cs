using Microsoft.EntityFrameworkCore;

namespace OrderProcessinSystem.Models
{
    public partial class OrdersContext : DbContext
    {
        public OrdersContext()
        {
        }

        public OrdersContext(DbContextOptions<OrdersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArticleDto> Articles { get; set; }
        public virtual DbSet<BillingAddressDto> BillingAddresses { get; set; }
        public virtual DbSet<OrderStatuseDto> OrderStatuses { get; set; }
        public virtual DbSet<OrderDto> Orders { get; set; }
        public virtual DbSet<PaymentDto> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<ArticleDto>(entity =>
            {
                entity.HasIndex(e => e.OrderOxId);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.OrderOx)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.OrderOxId);
            });

            modelBuilder.Entity<BillingAddressDto>(entity =>
            {
                entity.HasIndex(e => e.OrderOxId)
                    .IsUnique();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.OrderOx)
                    .WithOne(p => p.BillingAddresses)
                    .HasForeignKey<BillingAddressDto>(d => d.OrderOxId);
            });

            modelBuilder.Entity<OrderStatuseDto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderDto>(entity =>
            {
                entity.HasKey(e => e.OxId);

                entity.Property(e => e.OxId).ValueGeneratedNever();

                entity.Property(e => e.OrderDatetime).HasColumnType("smalldatetime");

                entity.HasOne(d => d.OrderStatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatus);
            });

            modelBuilder.Entity<PaymentDto>(entity =>
            {
                entity.HasIndex(e => e.OrderOxId);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MethodName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.OrderOx)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.OrderOxId);
            });
        }
    }
}
