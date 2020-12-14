namespace Shopping.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    public partial class PeachMd : DbContext
    {
        public PeachMd()
            : base("name=PeachMd")
        {
        }

        public virtual DbSet<Bankcard> Bankcard { get; set; }
        public virtual DbSet<Commodity> Commodity { get; set; }
        public virtual DbSet<DeliveryAddress> DeliveryAddress { get; set; }
        public virtual DbSet<Favorites> Favorites { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bankcard>()
                .Property(e => e.IdCard)
                .IsUnicode(false);

            modelBuilder.Entity<Bankcard>()
                .Property(e => e.BankPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Bankcard>()
                .Property(e => e.BankWebSite)
                .IsUnicode(false);

            modelBuilder.Entity<Bankcard>()
                .Property(e => e.BankCode)
                .IsUnicode(false);

            modelBuilder.Entity<Bankcard>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryAddress>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<DeliveryAddress>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Shop>()
                .Property(e => e.LicenseId)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.IdCard)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.MailBox)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Bankcard)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.DeliveryAddress)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Favorites)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Order)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CustomerID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Order1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.SellerID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Shop)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.SellerId)
                .WillCascadeOnDelete(false);
        }
    }
}
