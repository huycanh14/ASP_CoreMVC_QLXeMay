using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebQLXeMay.Models;
using WebQLXeMay.Services;

namespace WebQLXeMay.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly IKhachHang _khachhang;

        public KhachHangController(IKhachHang khachHang)
        {
            _khachhang = khachHang;
        }
        public IActionResult Index(int page = 1, string keyword = "")
        {
            var model = _khachhang.GetKhachHangs(page, keyword);
            ViewBag.keyword = keyword;
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
            return View();
        }

        [HttpPost]
        public IActionResult Create(KhachHang khachHang)
        {
            try
            {
                _khachhang.Add(khachHang);
                ViewBag.Done = "Thêm khách hàng thành công";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(khachHang);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var data = _khachhang.GetKhachHang(id);
            if (data == null)
            {
                return RedirectToAction("Index", "KhachHang");
            }
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(KhachHang khachHang)
        {
            try
            {
                _khachhang.Edit(khachHang);
                ViewBag.Done = "Sửa khách hàng thành công";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(khachHang);
        }

        public IActionResult Details(string id)
        {
            var data = _khachhang.GetKhachHang(id);
            if (data == null)
            {
                return RedirectToAction("Index", "KhachHang");
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var data = _khachhang.GetKhachHang(id);
            if (data == null)
            {
                return RedirectToAction("Index", "KhachHang");
            }
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(string id)
        {
            try
            {
                _khachhang.Remove(id);
                TempData["Done"] = "Xóa khách hàng thành công";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("Index", "NCC");
        }
    }
}