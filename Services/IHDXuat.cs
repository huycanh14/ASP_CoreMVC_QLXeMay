using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;

namespace WebQLXeMay.Services
{
    public interface IHDXuat
    {
        PagedList<HDXuatShow> HDXuats(int page);
        HDXuatShow GetHDXuat(string id);
        void Add(HDXuat _hdXuat);
        void Remove(string id);
        object Report(DateTime startTime, DateTime endTime);
    }
}
