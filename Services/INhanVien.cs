using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;

namespace WebQLXeMay.Services
{
    public interface INhanVien
    {
        IQueryable<NhanVien> GetAllNhanViens { get; }
        PagedList<NhanVien> GetNhanViens(int page, string keyword);
        NhanVien GetNhanVien(string id);
        void Add(NhanVien _nhanVien);
        void Edit(NhanVien _nhanVien);
        void Remove(string id);
        int Count { get; }
    }
}
