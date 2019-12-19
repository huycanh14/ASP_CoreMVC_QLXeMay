using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;

namespace WebQLXeMay.Services
{
    public interface INhanVien
    {
        IQueryable<NhanVien> GetNhanViens { get; }
        NhanVien GetNhanVien(string id);
        void Add(NhanVien _nhanVien);
        void Remove(string id);
        int Count { get; }
    }
}
