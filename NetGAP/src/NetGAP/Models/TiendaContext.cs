using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NetGAP.Models
{
    public partial class TiendaContext : DbContext
    {
        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-B7DB91V\LOCAL_SERVER;Database=Tienda;Integrated Security=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articles>(entity =>
            {
                entity.ToTable("articles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.TotalInShelf).HasColumnName("total_in_shelf");

                entity.Property(e => e.TotalInVault).HasColumnName("total_in_vault");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_articles_stores");
            });

            modelBuilder.Entity<Stores>(entity =>
            {
                entity.ToTable("stores");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(600);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });
        }
    }
}
