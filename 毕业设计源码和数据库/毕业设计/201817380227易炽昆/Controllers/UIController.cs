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
            if (UserLogin == null)
            {
                Session["User"] = null;
            }
            else
            {
                var user = db.User.Where(p => p.UserLogin == UserLogin).FirstOrDefault();
                Session["User"] = user;
            }
            var lease = db.LeaseHouse.Where(p => p.IsLease == "否").ToList();
            var sell = db.SellHouse.Where(p => p.IsSell == "否").ToList();
            ViewBag.lease = lease;
            ViewBag.sell = sell;
            return View();
        }
        /// <summary>
        /// 租房
        /// </summary>
        /// <returns></returns>
        public ActionResult LeaseHouse(string Position = "")
        {
            List<LeaseHouse> list = db.LeaseHouse.Where(p => (p.Position == Position && p.IsLease == "否") || (p.Position.Contains(Position) && p.IsLease == "否")).ToList();
            ViewBag.list = list;
            return View();
        }
        /// <summary>
        /// 租房详情页
        /// </summary>
        /// <param name="LeaseID"></param>
        /// <returns></returns>
        public ActionResult LeaseHouseMsg(int LeaseID)
        {
            LeaseHouse leaseHouse = db.LeaseHouse.Find(LeaseID);
            ViewBag.leaseHouse = leaseHouse;
            return View();
        }
        /// <summary>
        /// 买房
        /// </summary>
        /// <param name="Position"></param>
        /// <returns></returns>
        public ActionResult SellHouse(string Position="")
        {
            List<SellHouse> list = db.SellHouse.Where(p => (p.Position == Position && p.IsSell=="否") || (p.Position.Contains(Position) && p.IsSell=="否")).ToList();
            ViewBag.list = list;
            return View();
        }
        /// <summary>
        /// 买房详情页
        /// </summary>
        /// <param name="SellID"></param>
        /// <returns></returns>
        public ActionResult SellHouseMsg(int SellID)
        {
            SellHouse sellHouse = db.SellHouse.Find(SellID);
            ViewBag.sellHouse = sellHouse;
            return View();
        }
    }
}