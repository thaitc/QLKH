﻿// <auto-generated />
using System;
using DoAn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DoAn_Theme_2.Migrations
{
    [DbContext(typeof(DoAnContext))]
    [Migration("20221126140706_CreateDB")]
    partial class CreateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DoAn.Models.NhomHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NhomHangs");
                });

            modelBuilder.Entity("DoAn.Models.SanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("GiaBan")
                        .HasColumnType("float");

                    b.Property<double>("GiaVon")
                        .HasColumnType("float");

                    b.Property<int>("IdDonVi")
                        .HasColumnType("int");

                    b.Property<int>("IdNhomHang")
                        .HasColumnType("int");

                    b.Property<int>("IdThuongHieu")
                        .HasColumnType("int");

                    b.Property<string>("Ma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaVach")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThanhPhan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TonKho")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("DoAn.Models.ThuongHieu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ThuongHieus");
                });

            modelBuilder.Entity("DoAn_Theme_2.Models.ChiTietDonHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DonGia")
                        .HasColumnType("int");

                    b.Property<int>("IdDonHang")
                        .HasColumnType("int");

                    b.Property<int>("IdDonViTrietKhau")
                        .HasColumnType("int");

                    b.Property<int>("IdSanPham")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<int>("ThanhTien")
                        .HasColumnType("int");

                    b.Property<int>("TrietKhau")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ChiTietDonHangs");
                });

            modelBuilder.Entity("DoAn_Theme_2.Models.DonHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdKhachHang")
                        .HasColumnType("int");

                    b.Property<string>("Ma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySuaCuoi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoLuongSanPham")
                        .HasColumnType("int");

                    b.Property<int>("TongSoLuongSanPham")
                        .HasColumnType("int");

                    b.Property<double>("TongTien")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("DonHangs");
                });

            modelBuilder.Entity("DoAn_Theme_2.Models.DonVi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LoaiDonVi")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DonVis");
                });

            modelBuilder.Entity("DoAn_Theme_2.Models.KhachHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KhachHangs");
                });

            modelBuilder.Entity("DoAn_Theme_2.Models.TaiLieuSanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DuongDan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdSanPham")
                        .HasColumnType("int");

                    b.Property<string>("TenFile")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TaiLieuSanPhams");
                });

            modelBuilder.Entity("DoAn_Theme_2.Models.ThuocTinhOfSanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GiaTri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdSanPham")
                        .HasColumnType("int");

                    b.Property<int>("IdThuocTinh")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ThuocTinhOfSanPhams");
                });

            modelBuilder.Entity("DoAn_Theme_2.Models.ThuocTinhSanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ThuocTinhSanPhams");
                });
#pragma warning restore 612, 618
        }
    }
}