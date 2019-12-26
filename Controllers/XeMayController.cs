using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebQLXeMay.Models;
using WebQLXeMay.Services;

namespace WebQLXeMay.Controllers
{
    public class XeMayController : Controller
    {
        private readonly IXeMay _xemmay;
        private readonly INCC _ncc;
        public XeMayController(IXeMay xeMay, INCC nCC)
        {
            _xemmay = xeMay;
            _ncc = nCC;
        }
        public IActionResult Index(int page = 1, string keyword = "")
        {
            var model = _xemmay.GetXeMays(page, keyword);
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
            ViewBag.NCCs = _ncc.GetAllNCCs;
            return View();
        }

        [HttpPost]
        public IActionResult Create(XeMay xeMay)
        {
            try
            {
                _xemmay.Add(xeMay);
                
                ViewBag.Done = "Thêm xe máy thành công";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            ViewBag.NCCs = _ncc.GetAllNCCs;
            return View(xeMay);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var data = _xemmay.GetXeMay(id);
            if (data == null)
            {
                return RedirectToAction("Index", "XeMay");
            }
            ViewBag.NCCs = _ncc.GetAllNCCs;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(XeMay xeMay)
        {
            try
            {
                _xemmay.Edit(xeMay);
                ViewBag.Done = "Sửa xe máy thành công";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            ViewBag.NCCs = _ncc.GetAllNCCs;
            return View(xeMay);
        }

        public IActionResult Details(string id)
        {
            var data = _xemmay.GetXeMayShow(id);
            if (data == null)
            {
                return RedirectToAction("Index", "XeMay");
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var data = _xemmay.GetXeMayShow(id);
            if (data == null)
            {
                return RedirectToAction("Index", "XeMay");
            }
            return View(data);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(string id)
        {
            try
            {
                _xemmay.Remove(id);
                TempData["Done"] = "Xóa xe máy thành công";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("Index", "XeMay");
        }
    }
}