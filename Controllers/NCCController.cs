using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebQLXeMay.Models;
using WebQLXeMay.Services;

namespace WebQLXeMay.Controllers
{
    public class NCCController : Controller
    {
        private readonly INCC _ncc;
        public NCCController(INCC nCC)
        {
            _ncc = nCC;
        }
        public IActionResult Index(int page = 1, string keyword = "")
        {
            var model = _ncc.GetNCCs(page, keyword);
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
        public IActionResult Create(NCC ncc)
        {
            try
            {
                _ncc.Add(ncc);
                ViewBag.Done = "Thêm tài khoản thành công";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(ncc);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var data = _ncc.GetNCC(id);
            if(data == null)
            {
                return RedirectToAction("Index", "NCC");
            }
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(NCC ncc)
        {
            try
            {
                _ncc.Edit(ncc);
                ViewBag.Done = "Sửa tài khoản thành công";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(ncc);
        }

        public IActionResult Details(string id)
        {
            var data = _ncc.GetNCC(id);
            if (data == null)
            {
                return RedirectToAction("Index", "NCC");
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var data = _ncc.GetNCC(id);
            if (data == null)
            {
                return RedirectToAction("Index", "NCC");
            }
            return View(data);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(string id)
        {
            try
            {
                _ncc.Remove(id);
                TempData["Done"] = "Xóa tài khoản thành công";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("Index", "NCC");
        }
    }
}