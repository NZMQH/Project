using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _201817380227易炽昆.Models;

namespace _201817380227易炽昆.Controllers
{
    public class LeaseHouseController : Controller
    {
        HomeDBEntities db = new HomeDBEntities();
        // GET: LeaseHouse
        public ActionResult Index(string Position="")
        {
            var list = db.LeaseHouse.Where(p=>p.Position==Position || p.Position.Contains(Position)).ToList();
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult Index()
        {
            var list = db.LeaseHouse.Where(p => p.IsLease == "否").ToList();
            ViewBag.list = list;
            return View();
        }
        public ActionResult AddHouse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddHouse(LeaseHouse house)
        {
            db.LeaseHouse.Add(house);
            db.SaveChanges();
            return Content("<script >alert('添加成功');window.open('" + Url.Content("/LeaseHouse/Index") + "', '_self')</script >", "text/html");
        }
    }
}