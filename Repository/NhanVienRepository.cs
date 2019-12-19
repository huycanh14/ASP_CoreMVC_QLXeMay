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
        public IQueryable<NhanVien> GetNhanViens => db.NhanViens;
        public NhanVienRepository(DBContext _db)
        {
            db = _db;
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
        public int Count => db.NhanViens.Count();
    }
}
