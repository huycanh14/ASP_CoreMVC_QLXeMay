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
        IQueryable<KhachHang> GetKhachHangs { get; }
        KhachHang GetKhachHang(string id);
        void Add(KhachHang _khachHang);
        void Remove(string id);
        int Count { get; }

    }
}
