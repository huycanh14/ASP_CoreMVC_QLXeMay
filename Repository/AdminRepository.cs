using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;

namespace WebQLXeMay.Repository
{
    public class AdminRepository : IAdmin
    {
        private DBContext db;
        public AdminRepository(DBContext _db)
        {
            db = _db;
        }
        public IQueryable<Admin> GetAdmins => db.Admins;

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
    }
}
