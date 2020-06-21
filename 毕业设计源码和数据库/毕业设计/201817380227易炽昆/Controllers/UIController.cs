using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _201817380227易炽昆.Models;

namespace _201817380227易炽昆.Controllers
{
    public class UIController : Controller
    {
        HomeDBEntities db = new HomeDBEntities();
        // GET: UI
        /// <summary>
        /// 前端首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string UserLogin)
        {
            if (UserLogin==null)
            {
                Session["User"] = null;
            }
            else
            {
                var user= db.User.Where(p => p.UserLogin == UserLogin).FirstOrDefault();
                Session["User"] = user;
            }
            var lease = db.LeaseHouse.Where(p => p.IsLease == "否").ToList();
            var sell = db.SellHouse.Where(p => p.IsSell == "否").ToList();
            ViewBag.lease = lease;
            ViewBag.sell = sell;
            return View();
        }
        public ActionResult SelectHouse()
        {
            return View();
        }
    }
}