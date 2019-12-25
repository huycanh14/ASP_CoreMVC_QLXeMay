using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;

namespace WebQLXeMay.Services
{
    public interface IHDNhap
    {
        PagedList<HDNhapShow> GetHDNhaps(int page);
        HDNhapShow GetHDNhap(string id);
        void Add(HDNhap _hdNhap);
        void Remove(string id);
        object Report(DateTime startTime, DateTime endTime);
    }
}
