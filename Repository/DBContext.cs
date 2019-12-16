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
        DbSet<Admin> Admins { get; set; }
        DbSet<HDNhap> HDNhaps { get; set; }
        DbSet<HDXuat> HDXuats { get; set; }
        DbSet<KhachHang> KhachHangs { get; set; }
        DbSet<NCC> NCCs { get; set; }
        DbSet<NhanVien> NhanViens { get; set; }
        DbSet<XeMay> XeMays { get; set; }
    }
}
