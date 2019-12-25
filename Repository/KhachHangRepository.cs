using PagedList.Core;
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
        public KhachHangRepository(DBContext _db)
        {
            db = _db;
        }
        public IQueryable<KhachHang> GetAllKhachHangs => db.KhachHangs;
        public PagedList<KhachHang> GetKhachHangs(int page = 1, string keyword = "")
        {
            int pageSize = 5;
            var kh = (keyword != null) ? db.KhachHangs.Where(p => p.TenKH.Contains(keyword)) : db.KhachHangs;
            PagedList<KhachHang> data = new PagedList<KhachHang>(kh, page, pageSize);
            return data;
        }
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

        public void Edit(KhachHang khachHang)
        {
            db.KhachHangs.Update(khachHang);
            db.SaveChanges();
        }

        public int Count => db.KhachHangs.Count();
    }
}
