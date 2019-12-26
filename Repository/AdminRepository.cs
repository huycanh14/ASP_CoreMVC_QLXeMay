using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;
using WebQLXeMay.Services;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;

namespace WebQLXeMay.Repository
{
    public class AdminRepository : IAdmin
    {
        private DBContext db;
        public AdminRepository(DBContext _db)
        {
            db = _db;
        }
        //public IQueryable<Admin> GetAdmins => db.Admins;
        public PagedList<Admin> GetAdmins(int page, string keyword)
        {
            int pageSize = 5;
            var acc = (keyword != null) ? db.Admins.Where(p => p.HoVaTen.Contains(keyword)) : db.Admins;
            PagedList<Admin> data = new PagedList<Admin>(acc, page, pageSize);
            return data;
        }

        public void Add(Admin admin)
        {
            db.Admins.Add(admin);
            db.SaveChanges();
        }

        public Admin GetAdmin(int id)
        {
            return db.Admins.Find(id);
        }

        public void Remove(int id)
        {
            Admin dbEntity = db.Admins.Find(id);
            db.Admins.Remove(dbEntity);
            db.SaveChanges();
        }
        public Admin Login(string username, string password)
        {
            return db.Admins.Where(a => a.TenDangNhap == username && a.MatKhau == password)
                            .FirstOrDefault();
        }

        public void Edit(Admin admin)
        {
            db.Admins.Update(admin);
            db.SaveChanges();
        }
    }
}
