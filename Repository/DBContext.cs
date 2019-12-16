using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;

namespace WebQLXeMay.Repository
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<HDNhap> HDNhaps { get; set; }
        public DbSet<HDXuat> HDXuats { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<NCC> NCCs { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<XeMay> XeMays { get; set; }
    }
}
