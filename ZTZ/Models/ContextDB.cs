namespace ZTZ.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContextDB : DbContext
    {
        public ContextDB()
            : base("name=ContextDB")
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<LinesOrder> LinesOrder { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
