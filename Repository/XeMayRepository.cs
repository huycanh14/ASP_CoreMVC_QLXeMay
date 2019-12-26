using PagedList.Core;
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
        //public IQueryable<XeMay> GetXeMays => db.XeMays;
        public XeMayRepository(DBContext _db)
        {
            db = _db;
        }
        public PagedList<XeMayShow> GetXeMays(int page = 1, string keyword = "")
        {
            PagedList<XeMayShow> data;
            int pageSize = 5;
            if (keyword != null)
            {
                var xemays = (from xm in db.XeMays
                            join ncc in db.NCCs on xm.MaNCC equals ncc.MaNCC
                            where xm.TenXe.Contains(keyword)
                            select new XeMayShow
                            {
                                MaXe = xm.MaXe,
                                TenXe = xm.TenXe,
                                TenNCC = ncc.TenNCC,
                                DonGia = xm.DonGia,
                                SoLuong = xm.SoLuong,
                                MauSac = xm.MauSac
                            });
                data = new PagedList<XeMayShow>(xemays, page, pageSize);
            }
            else
            {
                var xemays = (from xm in db.XeMays
                            join ncc in db.NCCs on xm.MaNCC equals ncc.MaNCC
                            where xm.TenXe.Contains(keyword)
                            select new XeMayShow
                            {
                                MaXe = xm.MaXe,
                                TenXe = xm.TenXe,
                                TenNCC = ncc.TenNCC,
                                DonGia = xm.DonGia,
                                SoLuong = xm.SoLuong,
                                MauSac = xm.MauSac
                            });
                data = new PagedList<XeMayShow>(xemays, page, pageSize);
            }
            
            return data;
        }
        public void Add(XeMay _xeMay)
        {
            db.XeMays.Add(_xeMay);
            db.SaveChanges();
        }

        public XeMayShow GetXeMayShow(string id)
        {
            return (from xm in db.XeMays
                    join ncc in db.NCCs on xm.MaNCC equals ncc.MaNCC
                    where xm.MaXe.Equals(id)
                    select new XeMayShow
                    {
                        MaXe = xm.MaXe,
                        TenXe = xm.TenXe,
                        TenNCC = ncc.TenNCC,
                        DonGia = xm.DonGia,
                        SoLuong = xm.SoLuong,
                        MauSac = xm.MauSac
                    }).FirstOrDefault();
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

        public void Edit(XeMay _xeMay)
        {
            db.XeMays.Update(_xeMay);
            db.SaveChanges();
        }

        public int Count => db.XeMays.Count();

        public IQueryable<XeMay> GetAllXeMays => db.XeMays;
    }
}
