﻿// <auto-generated />
using System;
using API_QLHocVien.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_QLHocVien.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231109160918_v2")]
    partial class v2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_QLHocVien.Entites.BaiViet", b =>
                {
                    b.Property<int>("BaiVietID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BaiVietID"));

                    b.Property<int>("ChuDeID")
                        .HasColumnType("int");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoiDungNgan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaiKhoanID")
                        .HasColumnType("int");

                    b.Property<string>("TenBaiViet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenTacGia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ThoiGianTao")
                        .HasColumnType("datetime2");

                    b.HasKey("BaiVietID");

                    b.HasIndex("ChuDeID");

                    b.HasIndex("TaiKhoanID");

                    b.ToTable("BaiViet");
                });

            modelBuilder.Entity("API_QLHocVien.Entites.ChuDe", b =>
                {
                    b.Property<int>("ChuDeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChuDeID"));

                    b.Property<int>("LoaiBaiVietID")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenChuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChuDeID");

                    b.HasIndex("LoaiBaiVietID");

                    b.ToTable("ChuDe");
                });

            modelBuilder.Entity("API_QLHocVien.Entites.DangKyHoc", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("HocVienID")
                        .HasColumnType("int");

                    b.Property<int>("KhoaHocID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayDangKy")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<int>("TaiKhoanID")
                        .HasColumnType("int");

                    b.Property<int>("TinhTrangHocID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("HocVienID");

                    b.HasIndex("KhoaHocID");

                    b.HasIndex("TaiKhoanID");

                    b.HasIndex("TinhTrangHocID");

                    b.ToTable("DangKyHoc");
                });

            modelBuilder.Entity("API_QLHocVien.Entites.HocVien", b =>
                {
                    b.Property<int>("HocVienID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HocVienID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhuongXa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuanHuyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoNha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TinhThanh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HocVienID");

                    b.ToTable("HocVien");
                });

            modelBuilder.Entity("API_QLHocVien.Entites.KhoaHoc", b =>
                {
                    b.Property<int>("KhoaHocID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KhoaHocID"));

                    b.Property<string>("GioiThieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("HocPhi")
                        .HasColumnType("real");

                    b.Property<int>("LoaiKhoaHocID")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoHocVien")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongMon")
                        .HasColumnType("int");

                    b.Property<string>("TenKhoaHoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ThoiGianHoc")
                        .HasColumnType("int");

                    b.HasKey("KhoaHocID");

                    b.HasIndex("LoaiKhoaHocID");

                    b.ToTable("KhoaHoc");
                });

            modelBuilder.Entity("API_QLHocVien.Entites.LoaiBaiViet", b =>
                {
                    b.Property<int>("LoaiBaiVietID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoaiBaiVietID"));

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoaiBaiVietID");

                    b.ToTable("LoaiBaiViet");
                });

            modelBuilder.Entity("API_QLHocVien.Entites.LoaiKhoaHoc", b =>
                {
                    b.Property<int>("LoaiKhoaHocID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoaiKhoaHocID"));

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoaiKhoaHocID");

                    b.ToTable("LoaiKhoaHoc");
                });

            modelBuilder.Entity("API_QLHocVien.Entites.QuyenHan", b =>
                {
                    b.Property<int>("QuyenHanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuyenHanID"));

                    b.Property<string>("TenQuyenHan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuyenHanID");

                    b.ToTable("QuyenHan");
                });

            modelBuilder.Entity("API_QLHocVien.Entites.TaiKhoan", b =>
                {
                    b.Property<int>("TaiKhoanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaiKhoanID"));

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuyenHanID")
                        .HasColumnType("int");

                    b.Property<string>("TaiKhoanDN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNguoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaiKhoanID");

                    b.HasIndex("QuyenHanID");

                    b.ToTable("TaiKhoan");
                });

            modelBuilder.Entity("API_QLHocVien.Entites.TinhTrangHoc", b =>
                {
                    b.Property<int>("TinhTrangHocID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TinhTrangHocID"));

                    b.Property<string>("TenTinhTrang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TinhTrangHocID");

                    b.ToTable("TinhTrangHoc");
                });

            modelBuilder.Entity("API_QLHocVien.Entites.BaiViet", b =>
                {
                    b.HasOne("API_QLHocVien.Entites.ChuDe", "ChuDe")
                        .WithMany("BaiViets")
                        .HasForeignKey("ChuDeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_QLHocVien.Entites.TaiKhoan", "TaiKhoan")
                        .WithMany()
                        .HasForeignKey("TaiKhoanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChuDe");

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("API_QLHocVien.Entites.ChuDe", b =>
                {
                    b.HasOne("API_QLHocVien.Entites.LoaiBaiViet", "LoaiBaiViet")
                        .WithMany()
                        .HasForeignKey("LoaiBaiVietID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiBaiViet");
                });

            modelBuilder.Entity("API_QLHocVien.Entites.DangKyHoc", b =>
                {
                    b.HasOne("API_QLHocVien.Entites.HocVien", "HocVien")
                        .WithMany("DangKyHocs")
                        .HasForeignKey("HocVienID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_QLHocVien.Entites.KhoaHoc", "KhoaHoc")
                        .WithMany()
                        .HasForeignKey("KhoaHocID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_QLHocVien.Entites.TaiKhoan", "TaiKhoan")
                        .WithMany()
                        .HasForeignKey("TaiKhoanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_QLHocVien.Entites.TinhTrangHoc", "TinhTrangHoc")
                        .WithMany()
                        .HasForeignKey("TinhTrangHocID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HocVien");

                    b.Navigation("KhoaHoc");

                    b.Navigation("TaiKhoan");

                    b.Navigation("TinhTrangHoc");
                });

            modelBuilder.Entity("API_QLHocVien.Entites.KhoaHoc", b =>
                {
                    b.HasOne("API_QLHocVien.Entites.LoaiKhoaHoc", "LoaiKhoaHoc")
                        .WithMany("KhoaHocs")
                        .HasForeignKey("LoaiKhoaHocID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiKhoaHoc");
                });

            modelBuilder.Entity("API_QLHocVien.Entites.TaiKhoan", b =>
                {
                    b.HasOne("API_QLHocVien.Entites.QuyenHan", "QuyenHan")
                        .WithMany("TaiKhoans")
                        .HasForeignKey("QuyenHanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuyenHan");
                });

            modelBuilder.Entity("API_QLHocVien.Entites.ChuDe", b =>
                {
                    b.Navigation("BaiViets");
                });

            modelBuilder.Entity("API_QLHocVien.Entites.HocVien", b =>
                {
                    b.Navigation("DangKyHocs");
                });

            modelBuilder.Entity("API_QLHocVien.Entites.LoaiKhoaHoc", b =>
                {
                    b.Navigation("KhoaHocs");
                });

            modelBuilder.Entity("API_QLHocVien.Entites.QuyenHan", b =>
                {
                    b.Navigation("TaiKhoans");
                });
#pragma warning restore 612, 618
        }
    }
}
