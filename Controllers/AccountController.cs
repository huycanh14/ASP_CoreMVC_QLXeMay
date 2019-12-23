using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebQLXeMay.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebQLXeMay.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAdmin _Admin;
        public AccountController(IAdmin admin)
        {
            _Admin = admin;
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
            var data = _Admin.Login(username, password);
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
    }
}