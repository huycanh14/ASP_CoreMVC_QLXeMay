using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;

namespace WebQLXeMay.Services
{
    public interface INCC
    {
        IQueryable<NCC> GetNCCs { get; }
        NCC GetNCC(string id);
        void Add(NCC _ncc);
        void Remove(string id);
    }
}
