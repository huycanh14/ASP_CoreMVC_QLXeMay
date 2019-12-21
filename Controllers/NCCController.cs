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
    }
}