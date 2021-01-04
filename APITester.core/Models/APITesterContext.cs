using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APITester.Models
{
    public partial class APITesterContext : DbContext
    {
        public APITesterContext()
        {
        }

        public APITesterContext(DbContextOptions<APITesterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Requests> Requests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
            if (!optionsBuilder.IsConfigured)
            {
            }
            */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Requests>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Requests_pk")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateReceived)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });
        }
    }
}
