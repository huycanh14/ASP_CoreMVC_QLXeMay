using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;

namespace WebQLXeMay.Services
{
    public interface INCC
    {
        IQueryable<NCC> GetAllNCCs { get; }
        PagedList<NCC> GetNCCs(int page, string keyword);
        NCC GetNCC(string id);
        void Add(NCC _ncc);
        void Edit(NCC _ncc);
        void Remove(string id);
        int Count { get; }
    }
}
