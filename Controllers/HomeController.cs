using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebQLXeMay.Models;
using WebQLXeMay.Services;

namespace WebQLXeMay.Controllers
{
    public class HomeController : Controller
    {

        private readonly IAdmin _admin;
        private readonly INhanVien _nhanvien;
        private readonly INCC _ncc;
        private readonly IKhachHang _khachhang;
        private readonly IXeMay _xemay;

        public HomeController(IAdmin admin, INhanVien nhanVien, INCC nCC, IKhachHang khachHang, IXeMay xeMay)
        {
            _admin = admin;
            _nhanvien = nhanVien;
            _ncc = nCC;
            _khachhang = khachHang;
            _xemay = xeMay;
        }

        public IActionResult Index()
        {
            int[] count = new int[]
            {
                _nhanvien.Count, _ncc.Count, _khachhang.Count, _xemay.Count
            };
            ViewData["Count"] = count;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
