using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebQLXeMay.Models;
using WebQLXeMay.Services;

namespace WebQLXeMay.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly INhanVien _nhanvien;
        public NhanVienController(INhanVien nhanVien)
        {
            _nhanvien = nhanVien;
        }
        public IActionResult Index(int page = 1, string keyword = "")
        {
            var model = _nhanvien.GetNhanViens(page, keyword);
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
        public IActionResult Create(NhanVien nhanVien)
        {
            try
            {
                _nhanvien.Add(nhanVien);
                ViewBag.Done = "Thêm nhân viên thành công";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(nhanVien);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var data = _nhanvien.GetNhanVien(id);
            if (data == null)
            {
                return RedirectToAction("Index", "NhanVien");
            }
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(NhanVien nhanVien)
        {
            try
            {
                _nhanvien.Edit(nhanVien);
                ViewBag.Done = "Sửa nhân viên thành công";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(nhanVien);
        }

        public IActionResult Details(string id)
        {
            var data = _nhanvien.GetNhanVien(id);
            if (data == null)
            {
                return RedirectToAction("Index", "NhanVien");
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var data = _nhanvien.GetNhanVien(id);
            if (data == null)
            {
                return RedirectToAction("Index", "NhanVien");
            }
            return View(data);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(string id)
        {
            try
            {
                _nhanvien.Remove(id);
                TempData["Done"] = "Xóa nhân viên thành công";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("Index", "NhanVien");
        }
    }
}