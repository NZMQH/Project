using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _201817380227易炽昆.Models;

namespace _201817380227易炽昆.Controllers
{
    public class LoginController : Controller
    {
        HomeDBEntities db = new HomeDBEntities();
        // GET: Login
        //用户登录
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            var user1 = db.User.Where(p => p.UserLogin == user.UserLogin && p.UserPwd == user.UserPwd).ToList();
            if (user1.Count>0)
            {
                return Content("<script>alert('登录成功');</script>");
            }
            else
            {
                return Content("<script>alert('账号或密码输入错误，请重新输入！');javascript:history.go(-1)</script>");
                //return RedirectToAction("Index", "Login");
            }
            
        }
        //用户注册
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            var user1= db.User.Where(p =>p.UserLogin == user.UserLogin).ToList();
            if (user1.Count>0)
            {
                //ViewBag.ErrorMessage = "该账号已注册，请重新输入";
                return Content("<script>alert('该账号已注册');javascript:history.go(-1)</script>");
            }
            else
            {
                return Content("<script >alert('注册成功，跳转到登录页面');window.open('" + Url.Content("/Login/Index") + "', '_self')</script >", "text/html");
                //return RedirectToAction("Index", "Login");
            }
        }
        //管理员登录
        public ActionResult AdminLogin()
        {
            Session["Admin"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            
            var admin1 = db.Admin.Where(p => p.AdminLogin == admin.AdminLogin && p.AdminPwd == admin.AdminPwd).FirstOrDefault();
            if (admin1 !=null)
            {
                Session["Admin"] = admin1;
                return RedirectToAction("Index", "BackStage");
            }
            else
            {
                return Content("<script>alert('账号或密码输入错误，请重新输入！');javascript:history.go(-1)</script>");
                //return RedirectToAction("Index", "Login");
            }
        }
        //管理员注册
        public ActionResult AdminRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminRegister(Admin admin)
        {
            var admin1 = db.Admin.Where(p => p.AdminLogin == admin.AdminLogin).ToList();
            if (admin1.Count > 0)
            {
                //ViewBag.ErrorMessage = "该账号已注册，请重新输入";
                return Content("<script>alert('该账号已注册');javascript:history.go(-1)</script>");
            }
            else
            {
                db.Admin.Add(admin);
                db.SaveChanges();
                return Content("<script >alert('注册成功，跳转到登录页面');window.open('" + Url.Content("/Login/AdminLogin") + "', '_self')</script >", "text/html");
                //return RedirectToAction("Index", "Login");
            }
        }
    }
}