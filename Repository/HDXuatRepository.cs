using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;
using WebQLXeMay.Services;

namespace WebQLXeMay.Repository
{
    public class HDXuatRepository : IHDXuat
    {
        private DBContext db;
        
        public HDXuatRepository(DBContext _db)
        {
            db = _db;
        }
        public PagedList<HDXuatShow> HDXuats(int page)
        {
            int pageSize = 5;
            var hoadons = (from hdx in db.HDXuats
                           join kh in db.KhachHangs on hdx.MaKH equals kh.MaKH
                           join xm in db.XeMays on hdx.MaXe equals xm.MaXe
                           join nv in db.NhanViens on hdx.MaNhanVien equals nv.MaNhanVien
                           select new HDXuatShow
                           {
                               MaHoaDon = hdx.MaHoaDon,
                               TenXe = xm.TenXe,
                               TenKH = kh.TenKH,
                               TenNhanVien = nv.TenNhanVien,
                               DonGia = hdx.DonGia,
                               SoLuong = hdx.SoLuong,
                               NgayLap = hdx.NgayLap,
                               ThueGTGT = hdx.ThueGTGT,
                               ThanhTien = hdx.ThanhTien,
                               MauSac = hdx.MauSac,
                               SoKhung = hdx.SoKhung,
                               SoMay = hdx.SoMay,
                               BaoHanh = hdx.BaoHanh
                           });
            PagedList<HDXuatShow> data = new PagedList<HDXuatShow>(hoadons, page, pageSize);
            return data;
        }
        public void Add(HDXuat _hdXuat)
        {
            db.HDXuats.Add(_hdXuat);
            db.SaveChanges();
        }

        public HDXuat GetHDXuat(string id)
        {
            return db.HDXuats.Find(id);
        }

        public void Remove(string id)
        {
            HDXuat dbEntity = db.HDXuats.Find(id);
            db.HDXuats.Remove(dbEntity);
            db.SaveChanges();
        }

        public object Report(DateTime startTime, DateTime endTime)
        {
            var data = db.HDXuats
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
