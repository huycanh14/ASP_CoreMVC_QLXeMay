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
            bool log = _Admin.Login(username, password);
            if (log == true)
            {
                object[] account_login = new object[] { username, password};
                HttpContext.Session.SetString("account_login", JsonConvert.SerializeObject(account_login));
                
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