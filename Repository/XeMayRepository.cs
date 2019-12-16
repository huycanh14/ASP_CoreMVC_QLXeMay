using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;
using WebQLXeMay.Services;

namespace WebQLXeMay.Repository
{
    public class XeMayRepository : IXeMay
    {
        private DBContext db;
        public IQueryable<XeMay> GetXeMays => db.XeMays;
        public XeMayRepository(DBContext _db)
        {
            db = _db;
        }
        public void Add(XeMay _xeMay)
        {
            db.XeMays.Add(_xeMay);
            db.SaveChanges();
        }

        public XeMay GetXeMay(string id)
        {
            return db.XeMays.Find(id);
        }

        public void Remove(string id)
        {
            XeMay dbEntity = db.XeMays.Find(id);
            db.XeMays.Remove(dbEntity);
            db.SaveChanges();
        }
    }
}
