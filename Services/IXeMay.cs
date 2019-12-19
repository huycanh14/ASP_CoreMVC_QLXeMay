using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;

namespace WebQLXeMay.Services
{
    public interface IXeMay
    {
        IQueryable<XeMay> GetXeMays { get; }
        XeMay GetXeMay(string id);
        void Add(XeMay _xeMay);
        void Remove(string id);
        int Count { get; }
    }
}
