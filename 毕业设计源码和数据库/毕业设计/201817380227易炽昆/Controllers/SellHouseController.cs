using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _201817380227易炽昆.Models;

namespace _201817380227易炽昆.Controllers
{
    public class SellHouseController : Controller
    {
        HomeDBEntities db = new HomeDBEntities();
        // GET: SellHouse
        public ActionResult Index(string Position="")
        {
            var list = db.SellHouse.Where(p => p.Position == Position || p.Position.Contains(Position)).ToList();
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult Index()
        {
            var list = db.SellHouse.Where(p => p.IsSell == "否").ToList();
            ViewBag.list = list;
            return View();
        }
        public ActionResult AddHouse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddHouse(SellHouse house)
        {
            db.SellHouse.Add(house);
            db.SaveChanges();
            return Content("<script >alert('添加成功');window.open('" + Url.Content("/SellHouse/Index") + "', '_self')</script >", "text/html");
        }
        /// <summary>
        /// 查看出售房信息
        /// </summary>
        /// <param name="SellID"></param>
        /// <returns></returns>
        public ActionResult HouseSee(int SellID)
        {
            SellHouse sellHouse = db.SellHouse.Find(SellID);
            ViewBag.sellHouse = sellHouse;
            return View();
        }
        /// <summary>
        /// 修改房屋信息
        /// </summary>
        /// <returns></returns>
        public ActionResult HouseEdit(int SellID)
        {
            var sellHouse = db.SellHouse.Find(SellID);
            ViewBag.sellHouse = sellHouse;
            return View();
        }
        [HttpPost]
        public ActionResult HouseEdit(SellHouse sellHouse)
        {
            var sellHouse1 = db.SellHouse.Find(sellHouse.SellID);
            sellHouse1.Position = sellHouse.Position;
            sellHouse1.Describe = sellHouse.Describe;
            sellHouse1.Area = sellHouse.Area;
            sellHouse1.HouseType = sellHouse.HouseType;
            sellHouse1.SellPrice = sellHouse.SellPrice;
            sellHouse1.BuyType = sellHouse.BuyType;
            sellHouse1.IsSell = sellHouse.IsSell;
            sellHouse1.Contacts = sellHouse.Contacts;
            sellHouse1.ContactsPhone = sellHouse.ContactsPhone;
            sellHouse1.HousePhone = sellHouse.HousePhone;
            db.SaveChanges();
            ViewBag.sellHouse = sellHouse1;
            return Content("<script >alert('修改成功');window.open('" + Url.Content("/SellHouse/HouseEdit?SellID=" + sellHouse1.SellID) + "', '_self')</script >", "text/html");
        }
        /// <summary>
        /// 删除房屋信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult HouseDelete(int SellID)
        {
            var sellHouse = db.SellHouse.Find(SellID);
            if (sellHouse.BuyType==0)
            {
                List<BuyHouse> list = db.BuyHouse.Where(p => p.SellID == SellID).ToList();
                if (list.Count > 0)
                {
                    return Content("<script >alert('该房有客户存在，不能删除');window.history.go(-1);</script >", "text/html");
                }
                else
                {
                    SellHouse sell = db.SellHouse.Find(SellID);
                    db.SellHouse.Remove(sell);
                    db.SaveChanges();
                    return Content("<script >alert('删除成功');window.open('" + Url.Content("/SellHouse/Index") + "', '_self')</script >", "text/html");
                }
            }
            else if(sellHouse.BuyType==1)
            {
                List<StagesBuyHouse> list = db.StagesBuyHouse.Where(p => p.SellID == SellID).ToList();
                if (list.Count > 0)
                {
                    return Content("<script >alert('该房有客户存在，不能删除');window.history.go(-1);</script >", "text/html");
                }
                else
                {
                    SellHouse sell = db.SellHouse.Find(SellID);
                    db.SellHouse.Remove(sell);
                    db.SaveChanges();
                    return Content("<script >alert('删除成功');window.open('" + Url.Content("/SellHouse/Index") + "', '_self')</script >", "text/html");
                }
            }
            else
            {
                SellHouse sell = db.SellHouse.Find(SellID);
                db.SellHouse.Remove(sell);
                db.SaveChanges();
                return Content("<script >alert('删除成功');window.open('" + Url.Content("/SellHouse/Index") + "', '_self')</script >", "text/html");
            }
        }
        /// <summary>
        /// 添加客户
        /// </summary>
        /// <returns></returns>
        public ActionResult HouseUser(int SellID,string UserName)
        {
            SellHouse sellHouse = db.SellHouse.Find(SellID);
            List<User> list = db.User.Where(p => p.UserName == UserName || p.UserName.Contains(UserName)).ToList();
            ViewBag.list = list;
            ViewBag.sellHouse = sellHouse;
            return View();
        }
        [HttpPost]
        public ActionResult HouseUser(SellHouse sellHouse)
        {
            
            return View();
        }
    }
}