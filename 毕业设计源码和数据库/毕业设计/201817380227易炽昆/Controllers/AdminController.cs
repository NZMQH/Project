using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _201817380227易炽昆.Models;

namespace _201817380227易炽昆.Controllers
{
    public class AdminController : Controller
    {
        HomeDBEntities db = new HomeDBEntities();
        // GET: Admin
        public ActionResult Index(string AdminName="")
        {
            var list = db.Admin.Where(p => p.AdminName == AdminName || p.AdminName.Contains(AdminName)).ToList();
            ViewBag.list = list;
            return View();
        }
        public ActionResult AdminSee(int AdminID)
        {
            var admin = db.Admin.Find(AdminID);
            ViewBag.Admin = admin;
            return View();
        }
        public ActionResult AdminEdit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEdit(Admin admin)
        {
            Admin admin1 = db.Admin.Find(admin.AdminID);
            admin1.AdminID = admin.AdminID;
            admin1.AdminLogin = admin.AdminLogin;
            admin1.AdminPwd = admin.AdminPwd;
            admin1.AdminName = admin.AdminName;
            admin1.AdminIdentity = admin.AdminIdentity;
            admin1.AdminSex = admin.AdminSex;
            admin1.AdminAge = admin.AdminAge;
            admin1.AdminPhone = admin.AdminPhone;
            admin1.State = admin.State;
            db.SaveChanges();
            Session["Admin"] = admin1;
            return Content("<script >alert('修改成功');window.open('" + Url.Content("/Admin/AdminEdit?AdminID=" + admin1.AdminID) + "', '_self')</script >", "text/html");
        }
    }
}