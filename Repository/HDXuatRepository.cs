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
        public IQueryable<HDXuat> HDXuats => db.HDXuats;
        public HDXuatRepository(DBContext _db)
        {
            db = _db;
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
