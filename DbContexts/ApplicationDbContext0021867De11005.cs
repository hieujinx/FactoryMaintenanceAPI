using Microsoft.EntityFrameworkCore;
using DaoMinhHieu0021867.Entities;

namespace DaoMinhHieu0021867.DbContexts
{
    public class ApplicationDbContext0021867De11005 : DbContext
    {
        public ApplicationDbContext0021867De11005(DbContextOptions<ApplicationDbContext0021867De11005> options)
            : base(options)
        {
        }

        public DbSet<Technician0021867De11005> Technicians { get; set; }
        public DbSet<Equipment0021867De11005> Equipment { get; set; }
        public DbSet<Repair0021867De11005> Repairs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Technician0021867De11005>()
                .HasIndex(t => t.MaKyThuatVien)
                .IsUnique();

            modelBuilder.Entity<Technician0021867De11005>()
                .HasIndex(t => t.TenKyThuatVien)
                .IsUnique();

            modelBuilder.Entity<Technician0021867De11005>()
                .HasIndex(t => t.CCCD)
                .IsUnique();

            modelBuilder.Entity<Equipment0021867De11005>()
                .HasIndex(e => e.MaThietBi)
                .IsUnique();

            modelBuilder.Entity<Equipment0021867De11005>()
                .HasIndex(e => e.TenThietBi)
                .IsUnique();
        }
    }
} 