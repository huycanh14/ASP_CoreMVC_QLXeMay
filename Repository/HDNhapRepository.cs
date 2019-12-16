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
        public IQueryable<HDNhap> GetHDNhaps => db.HDNhaps;

        public void Add(HDNhap _hdNhap)
        {
            db.HDNhaps.Add(_hdNhap);
            db.SaveChanges();
        }

        public HDNhap GetHDNhap(string id)
        {
            return db.HDNhaps.Find(id);
        }

        public void Remove(string id)
        {
            HDNhap dbEntity = db.HDNhaps.Find(id);
            db.HDNhaps.Remove(dbEntity);
            db.SaveChanges();
        }
    }
}
