using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;

namespace WebQLXeMay.Services
{
    public interface IHDNhap
    {
        IQueryable<HDNhap> GetHDNhaps { get; }
        HDNhap GetHDNhap(string id);
        void Add(HDNhap _hdNhap);
        void Remove(string id);
    }
}
