using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;
using WebQLXeMay.Services;

namespace WebQLXeMay.Repository
{
    public class NCCRepository : INCC
    {
        private DBContext db;
        public IQueryable<NCC> GetNCCs => db.NCCs;
        public NCCRepository(DBContext _db)
        {
            db = _db;
        }
        public void Add(NCC _ncc)
        {
            db.NCCs.Add(_ncc);
            db.SaveChanges();
        }

        public NCC GetNCC(string id)
        {
            return db.NCCs.Find(id);
        }

        public void Remove(string id)
        {
            NCC dbEntity = db.NCCs.Find(id);
            db.NCCs.Remove(dbEntity);
            db.SaveChanges();
        }
        public int Count => db.NCCs.Count();
    }
}
