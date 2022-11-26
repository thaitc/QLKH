using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAn_Theme_2.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiTietDonHangs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDonHang = table.Column<int>(nullable: false),
                    IdSanPham = table.Column<int>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false),
                    DonGia = table.Column<int>(nullable: false),
                    TrietKhau = table.Column<int>(nullable: false),
                    IdDonViTrietKhau = table.Column<int>(nullable: false),
                    ThanhTien = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonHangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DonHangs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma = table.Column<string>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: false),
                    IdKhachHang = table.Column<int>(nullable: false),
                    SoLuongSanPham = table.Column<int>(nullable: false),
                    TongSoLuongSanPham = table.Column<int>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true),
                    TongTien = table.Column<double>(nullable: false),
                    NgaySuaCuoi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DonVis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(nullable: true),
                    LoaiDonVi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonVis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma = table.Column<string>(nullable: true),
                    Ten = table.Column<string>(nullable: true),
                    SoDienThoai = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhomHangs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhomHangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma = table.Column<string>(nullable: true),
                    Ten = table.Column<string>(nullable: true),
                    MaVach = table.Column<string>(nullable: true),
                    GiaBan = table.Column<double>(nullable: false),
                    GiaVon = table.Column<double>(nullable: false),
                    TonKho = table.Column<int>(nullable: false),
                    MoTa = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true),
                    ThanhPhan = table.Column<string>(nullable: true),
                    IdNhomHang = table.Column<int>(nullable: false),
                    IdThuongHieu = table.Column<int>(nullable: false),
                    IdDonVi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaiLieuSanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenFile = table.Column<string>(nullable: true),
                    DuongDan = table.Column<string>(nullable: true),
                    IdSanPham = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiLieuSanPhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThuocTinhOfSanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdThuocTinh = table.Column<int>(nullable: false),
                    IdSanPham = table.Column<int>(nullable: false),
                    GiaTri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuocTinhOfSanPhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThuocTinhSanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuocTinhSanPhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThuongHieus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuongHieus", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDonHangs");

            migrationBuilder.DropTable(
                name: "DonHangs");

            migrationBuilder.DropTable(
                name: "DonVis");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "NhomHangs");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "TaiLieuSanPhams");

            migrationBuilder.DropTable(
                name: "ThuocTinhOfSanPhams");

            migrationBuilder.DropTable(
                name: "ThuocTinhSanPhams");

            migrationBuilder.DropTable(
                name: "ThuongHieus");
        }
    }
}
