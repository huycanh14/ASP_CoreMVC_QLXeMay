using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebQLXeMay.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebQLXeMay.Models;

namespace WebQLXeMay.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAdmin _admin;
        public AccountController(IAdmin admin)
        {
            _admin = admin;
        }
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("Login")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Login(string username, string password)
        {
            var data = _admin.Login(username, password);
            if (data != null)
            {
                string data_account = data.TenDangNhap + "," + data.HoVaTen + "," + data.ID;
                HttpContext.Session.SetString("account_login", data_account);
            }
            else
            {
                ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng";
                ViewBag.Username = username;
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index(int page = 1, string keyword = "")
        {
            var model = _admin.GetAdmins(page, keyword);
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Admin admin)
        {
            try
            {
                _admin.Add(admin);
                ViewBag.Done = "Thêm tài khoản thành công";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(admin);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _admin.GetAdmin(id);
            if (data == null)
            {
                return RedirectToAction("Index", "Account");
            }
            data.MatKhau = "";
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Admin admin)
        {
            try
            {
                _admin.Edit(admin);
                ViewBag.Done = "Sửa tài khoản thành công";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(admin);
        }

        public IActionResult Details(int id)
        {
            var data = _admin.GetAdmin(id);
            if (data == null)
            {
                return RedirectToAction("Index", "Account");
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _admin.GetAdmin(id);
            if (data == null)
            {
                return RedirectToAction("Index", "Account");
            }
            return View(data);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            try
            {
                _admin.Remove(id);
                TempData["Done"] = "Xóa tài khoản thành công";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("Index", "Account");
        }
    }
}