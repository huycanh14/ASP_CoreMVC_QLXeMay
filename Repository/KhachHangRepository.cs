using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;
using WebQLXeMay.Services;

namespace WebQLXeMay.Repository
{
    public class KhachHangRepository : IKhachHang
    {
        private DBContext db;
        public IQueryable<KhachHang> GetKhachHangs => db.KhachHangs;

        public void Add(KhachHang _khachHang)
        {
            db.KhachHangs.Add(_khachHang);
            db.SaveChanges();
        }

        public KhachHang GetKhachHang(string id)
        {
            return db.KhachHangs.Find(id);
        }

        public void Remove(string id)
        {
            KhachHang dbEnity = db.KhachHangs.Find(id);
            db.KhachHangs.Remove(dbEnity);
            db.SaveChanges();
        }
    }
}
