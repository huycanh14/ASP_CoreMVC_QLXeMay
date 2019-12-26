using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;
using WebQLXeMay.Services;

namespace WebQLXeMay.Repository
{
    public class NhanVienRepository : INhanVien
    {
        private DBContext db;
        public NhanVienRepository(DBContext _db)
        {
            db = _db;
        }
        public IQueryable<NhanVien> GetAllNhanViens => db.NhanViens;
        public PagedList<NhanVien> GetNhanViens(int page, string keyword)
        {
            int pageSize = 5;
            var nv = (keyword != null) ? db.NhanViens.Where(p => p.TenNhanVien.Contains(keyword)) : db.NhanViens;
            PagedList<NhanVien> data = new PagedList<NhanVien>(nv, page, pageSize);
            return data;
        }
        public void Add(NhanVien _nhanVien)
        {
            db.NhanViens.Add(_nhanVien);
            db.SaveChanges();
        }

        public NhanVien GetNhanVien(string id)
        {
            return db.NhanViens.Find(id);
        }

        public void Remove(string id)
        {
            NhanVien dbEntity = db.NhanViens.Find(id);
            db.NhanViens.Remove(dbEntity);
            db.SaveChanges();
        }

        public void Edit(NhanVien _nhanVien)
        {
            db.NhanViens.Update(_nhanVien);
            db.SaveChanges();
        }

        public int Count => db.NhanViens.Count();
    }
}
