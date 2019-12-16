using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;

namespace WebQLXeMay.Services
{
    public interface IHDXuat
    {
        IQueryable<HDXuat> HDXuats { get; }
        HDXuat GetHDXuat(string id);
        void Add(HDXuat _hdXuat);
        void Remove(string id);
    }
}
