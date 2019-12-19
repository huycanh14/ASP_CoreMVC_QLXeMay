using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Report(string startTime, string endTime)
        {
            var data = _hdxuat.Report(Convert.ToDateTime(startTime), Convert.ToDateTime(endTime));
            return Json(new { data});
        }
    }
}