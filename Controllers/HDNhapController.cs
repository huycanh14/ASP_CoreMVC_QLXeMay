using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using WebQLXeMay.Models;
using WebQLXeMay.Services;

namespace WebQLXeMay.Controllers
{
    public class HDNhapController : Controller
    {
        private readonly IHDNhap _hdnhap;
        private readonly IXeMay _xemay;
        private readonly INhanVien _nhanvien;
        private readonly IKhachHang _khachhang;
        public HDNhapController(IHDNhap hDNhap, IXeMay xeMay, INhanVien nhanVien, IKhachHang khachHang)
        {
            _hdnhap = hDNhap;
            _xemay = xeMay;
            _nhanvien = nhanVien;
            _khachhang = khachHang;
        }
        public IActionResult Index(int page = 1)
        {
            PagedList<HDNhapShow> model = _hdnhap.GetHDNhaps(page);
            if (TempData["Done"] != null || TempData["Error"] != null)
            {
                ViewBag.Done = TempData["Done"];
                ViewBag.Error = TempData["Error"];
                TempData.Remove("Done");
                TempData.Remove("Error");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.NhanViens = _nhanvien.GetNhanViens;
            ViewBag.XeMays = _xemay.GetXeMays;
            return View();
        }

        [HttpPost]
        public IActionResult Create(HDNhap hDNhap)
        {
            var date = DateTime.Now;
            hDNhap.NgayLap = DateTime.Parse(date.ToString("yyyy-MM-dd HH:mm:ss"));
            try
            {
                _hdnhap.Add(hDNhap);
                ViewBag.Done = "Thêm hóa đơn thành công";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            ViewBag.NhanViens = _nhanvien.GetNhanViens;
            ViewBag.XeMays = _xemay.GetXeMays;
            return View(hDNhap);
        }

        public IActionResult Details(string id)
        {
            var data = _hdnhap.GetHDNhap(id);
            if (data == null)
            {
                return RedirectToAction("Index", "HDNhap");
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var data = _hdnhap.GetHDNhap(id);
            if (data == null)
            {
                return RedirectToAction("Index", "HDNhap");
            }
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(string id)
        {
            try
            {
                _hdnhap.Remove(id);
                TempData["Done"] = "Xóa đơn nhap thành công";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("Index", "HDNhap");
        }

        [HttpGet]
        public IActionResult Reports()
        {
            return View();
        }

        public JsonResult Report(string startTime, string endTime)
        {
            var data = _hdnhap.Report(Convert.ToDateTime(startTime), Convert.ToDateTime(endTime));
            return Json(new { data });
        }
    }
}