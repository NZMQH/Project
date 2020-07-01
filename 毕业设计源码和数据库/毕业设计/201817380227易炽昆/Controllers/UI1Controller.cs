using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _201817380227易炽昆.Models;

namespace _201817380227易炽昆.Controllers
{
    public class UI1Controller : Controller
    {
        HomeDBEntities db = new HomeDBEntities();
        // GET: UI1
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="UserLogin"></param>
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
        /// 租房页
        /// </summary>
        /// <returns></returns>
        public ActionResult Lease( string Position = "")
        {
            ViewBag.leaseHouse= db.LeaseHouse.Where(p => (p.Position == Position && p.IsLease == "否") || (p.Position.Contains(Position) && p.IsLease == "否")).ToList();
            return View();
        }
        /// <summary>
        /// 租房详情
        /// </summary>
        /// <returns></returns>
        public ActionResult LeaseHouseMsg(int LeaseID)
        {
            var leaseHouse = db.LeaseHouse.Find(LeaseID);
            var pic = db.Picture.Where(p => p.LeaseID == LeaseID).ToList();
            ViewBag.leaseHouse = leaseHouse;
            ViewBag.pic = pic;
            return View();
        }

        /// <summary>
        /// 购房页
        /// </summary>
        /// <returns></returns>
        public ActionResult Sell(string Position = "")
        {
            ViewBag.sellHouse = db.SellHouse.Where(p => (p.Position == Position && p.IsSell == "否") || (p.Position.Contains(Position) && p.IsSell == "否")).ToList();
            return View();
        }
        /// <summary>
        /// 购房详情
        /// </summary>
        /// <param name="SellID"></param>
        /// <returns></returns>
        public ActionResult SellHouseMsg(int SellID)
        {
            var sellHouse = db.SellHouse.Find(SellID);
            var pic = db.Picture.Where(p => p.SellID == SellID).ToList();
            ViewBag.sellHouse = sellHouse;
            ViewBag.pic = pic;
            return View();
        }

        /// <summary>
        /// 关于
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            return View();
        }

    }
}