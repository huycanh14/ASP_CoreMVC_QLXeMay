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
    public class HDXuatController : Controller
    {
        private readonly IHDXuat _hdxuat;
        private readonly IXeMay _xemay;
        private readonly INhanVien _nhanvien;
        private readonly IKhachHang _khachhang;
        public HDXuatController(IHDXuat hDXuat, IXeMay xeMay, INhanVien nhanVien, IKhachHang khachHang)
        {
            _hdxuat = hDXuat;
            _xemay = xeMay;
            _nhanvien = nhanVien;
            _khachhang = khachHang;
        }
        public IActionResult Index(int page = 1)
        {
            PagedList<HDXuatShow> model = _hdxuat.HDXuats(page);
            if (TempData["Done"] != null || TempData["Error"] != null)
            {
                ViewBag.Done = TempData["Done"];
                ViewBag.Error = TempData["Error"];
                TempData.Remove("Done");
                TempData.Remove("Error");
            }
            return View(model);
        }
        public JsonResult Report(string startTime, string endTime)
        {
            var data = _hdxuat.Report(Convert.ToDateTime(startTime), Convert.ToDateTime(endTime));
            return Json(new { data});
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.NhanViens = _nhanvien.GetNhanViens;
            ViewBag.KhachHangs = _khachhang.GetAllKhachHangs;
            ViewBag.XeMays = _xemay.GetAllXeMays;
            return View();
        }

        [HttpPost]
        public IActionResult Create(HDXuat hDXuat)
        {
            var date = DateTime.Now;
            hDXuat.NgayLap = DateTime.Parse(date.ToString("yyyy-MM-dd HH:mm:ss"));
            //hDXuat.ThanhTien = (hDXuat.DonGia * hDXuat.SoLuong + ((hDXuat.DonGia * hDXuat.SoLuong) * hDXuat.ThueGTGT) / (100));
            try
            {
                _hdxuat.Add(hDXuat);
                ViewBag.Done = "Thêm hóa đơn thành công";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            ViewBag.NhanViens = _nhanvien.GetNhanViens;
            ViewBag.KhachHangs = _khachhang.GetAllKhachHangs;
            ViewBag.XeMays = _xemay.GetAllXeMays;
            return View(hDXuat);
        }

        public IActionResult Details(string id)
        {
            var data = _hdxuat.GetHDXuat(id);
            if (data == null)
            {
                return RedirectToAction("Index", "HDXuat");
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var data = _hdxuat.GetHDXuat(id);
            if (data == null)
            {
                return RedirectToAction("Index", "HDXuat");
            }
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(string id)
        {
            try
            {
                _hdxuat.Remove(id);
                TempData["Done"] = "Xóa đơn xuất thành công";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("Index", "HDXuat");
        }

        [HttpGet]
        public IActionResult Reports()
        {
            return View();
        }
    }
}