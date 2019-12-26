using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;

namespace WebQLXeMay.Services
{
    public interface IXeMay
    {
        IQueryable<XeMay> GetAllXeMays { get; }
        PagedList<XeMayShow> GetXeMays(int page, string keyword);
        XeMayShow GetXeMayShow(string id);
        XeMay GetXeMay(string id);
        void Add(XeMay _xeMay);
        void Edit(XeMay _xeMay);
        void Remove(string id);
        int Count { get; }
    }
}
