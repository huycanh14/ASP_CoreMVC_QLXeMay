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
        public HDXuatController(IHDXuat hDXuat)
        {
            _hdxuat = hDXuat;
        }
        public IActionResult Index(int page = 1)
        {
            PagedList<HDXuatShow> model = _hdxuat.HDXuats(page);
            ViewBag.Data = Json(new { model });
            return View(model);
        }
        public JsonResult Report(string startTime, string endTime)
        {
            var data = _hdxuat.Report(Convert.ToDateTime(startTime), Convert.ToDateTime(endTime));
            return Json(new { data});
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}