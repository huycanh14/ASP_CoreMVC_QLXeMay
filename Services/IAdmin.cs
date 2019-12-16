using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;

namespace WebQLXeMay.Repository
{
    public interface IAdmin
    {
        IQueryable<Admin> GetAdmins { get; }
        Admin GetAdmin(int id);
        void Add(Admin admin);
        void Remove(int id);
    }
}
