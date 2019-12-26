using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLXeMay.Models;

namespace WebQLXeMay.Services
{
    public interface IAdmin
    {
        //IQueryable<Admin> GetAdmins { get; }
        PagedList<Admin> GetAdmins(int page, string keyword);
        Admin GetAdmin(int id);
        void Add(Admin admin);
        void Edit(Admin admin);
        void Remove(int id);
        Admin Login(string username, string password);
    }
}
