using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;

namespace WebQLXeMay.Services
{
    public interface IKhachHang
    {
        //IEnumerable<KhachHang> GetKhachHangs { get; }
        IQueryable<KhachHang> GetAllKhachHangs { get; }
        PagedList<KhachHang> GetKhachHangs(int page, string keyword);
        KhachHang GetKhachHang(string id);
        void Add(KhachHang _khachHang);
        void Edit(KhachHang khachHang);
        void Remove(string id);
        int Count { get; }

    }
}
