using DoAn_Theme_2.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAn.Models
{
    public class DoAnContext : DbContext
    {
        public DoAnContext(DbContextOptions<DoAnContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        //entities
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<ThuongHieu> ThuongHieus { get; set; }
        public DbSet<NhomHang> NhomHangs { get; set; }
        public DbSet<TaiLieuSanPham> TaiLieuSanPhams { get; set; }
        public DbSet<ThuocTinhSanPham> ThuocTinhSanPhams { get; set; }
        public DbSet<ThuocTinhOfSanPham> ThuocTinhOfSanPhams { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DbSet<DonVi> DonVis { get; set; }
    }
}
