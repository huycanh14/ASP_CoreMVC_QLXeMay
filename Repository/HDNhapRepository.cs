using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;
using WebQLXeMay.Services;

namespace WebQLXeMay.Repository
{
    public class HDNhapRepository : IHDNhap
    {
        private DBContext db;
        public HDNhapRepository(DBContext _db)
        {
            db = _db;
        }
        public PagedList<HDNhapShow> GetHDNhaps(int page)
        {
            int pageSize = 5;
            var hoadons = (from hdn in db.HDNhaps
                           join xm in db.XeMays on hdn.MaXe equals xm.MaXe
                           join nv in db.NhanViens on hdn.MaNhanVien equals nv.MaNhanVien
                           select new HDNhapShow
                           {
                               MaHoaDon = hdn.MaHoaDon,
                               TenXe = xm.TenXe,
                               TenNhanVien = nv.TenNhanVien,
                               DonGia = hdn.DonGia,
                               SoLuong = hdn.SoLuong,
                               NgayLap = hdn.NgayLap,
                               ThueGTGT = hdn.ThueGTGT,
                               ThanhTien = (hdn.DonGia * hdn.SoLuong + ((hdn.DonGia * hdn.SoLuong) * hdn.ThueGTGT) / (100)),
                               MauSac = hdn.MauSac,
                           });
            PagedList<HDNhapShow> data = new PagedList<HDNhapShow>(hoadons, page, pageSize);
            return data;
        }

        public void Add(HDNhap _hdNhap)
        {
            db.HDNhaps.Add(_hdNhap);
            db.SaveChanges();
        }

        public HDNhapShow GetHDNhap(string id)
        {
            return (from hdn in db.HDNhaps
                    join xm in db.XeMays on hdn.MaXe equals xm.MaXe
                    join nv in db.NhanViens on hdn.MaNhanVien equals nv.MaNhanVien
                    where hdn.MaHoaDon == id
                    select new HDNhapShow
                    {
                        MaHoaDon = hdn.MaHoaDon,
                        TenXe = xm.TenXe,
                        TenNhanVien = nv.TenNhanVien,
                        DonGia = hdn.DonGia,
                        SoLuong = hdn.SoLuong,
                        NgayLap = hdn.NgayLap,
                        ThueGTGT = hdn.ThueGTGT,
                        ThanhTien = (hdn.DonGia * hdn.SoLuong + ((hdn.DonGia * hdn.SoLuong) * hdn.ThueGTGT) / (100)),
                        MauSac = hdn.MauSac,
                    }).FirstOrDefault();
        }

        public void Remove(string id)
        {
            HDNhap dbEntity = db.HDNhaps.Find(id);
            db.HDNhaps.Remove(dbEntity);
            db.SaveChanges();
        }

        public object Report(DateTime startTime, DateTime endTime)
        {
            var data = db.HDNhaps
                          .Where(x => x.NgayLap >= startTime && x.NgayLap <= endTime)
                          .GroupBy(x => new { x.MaXe })
                          .Select(x => new
                          {
                              MaXe = x.Key.MaXe,
                              SoLuong = x.Sum(s => s.SoLuong)
                          });
            return data;
        }
    }
}
