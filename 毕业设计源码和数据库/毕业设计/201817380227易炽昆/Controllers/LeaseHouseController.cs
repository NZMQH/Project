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
        public ActionResult Index(string Position = "")
        {
            var list = db.LeaseHouse.Where(p => p.Position == Position || p.Position.Contains(Position)).ToList();
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
        /// <summary>
        /// 修改房屋信息
        /// </summary>
        /// <returns></returns>
        public ActionResult HouseEdit(int LeaseID)
        {
            var leaseHouse = db.LeaseHouse.Find(LeaseID);
            ViewBag.leaseHouse = leaseHouse;
            return View();
        }
        [HttpPost]
        public ActionResult HouseEdit(LeaseHouse leaseHouse)
        {
            var leaseHouse1 = db.LeaseHouse.Find(leaseHouse.LeaseID);
            leaseHouse1.Position = leaseHouse.Position;
            leaseHouse1.Describe = leaseHouse.Describe;
            leaseHouse1.Area = leaseHouse.Area;
            leaseHouse1.HouseType = leaseHouse.HouseType;
            leaseHouse1.Price = leaseHouse.Price;
            leaseHouse1.LeaseFurniture = leaseHouse.LeaseFurniture;
            leaseHouse1.LeaseType = leaseHouse.LeaseType;
            leaseHouse1.IsLease = leaseHouse.IsLease;
            leaseHouse1.Contacts = leaseHouse.Contacts;
            leaseHouse1.ContactsPhone = leaseHouse.ContactsPhone;
            leaseHouse1.HousePhone = leaseHouse.HousePhone;
            db.SaveChanges();
            ViewBag.leaseHouse = leaseHouse1;
            return Content("<script >alert('修改成功');window.open('" + Url.Content("/LeaseHouse/HouseEdit?LeaseID=" + leaseHouse1.LeaseID) + "', '_self')</script >", "text/html");
        }
        /// <summary>
        /// 查看出租房屋信息
        /// </summary>
        /// <param name="LeaseID"></param>
        /// <returns></returns>
        public ActionResult HouseSee(int LeaseID)
        {
            LeaseHouse leaseHouse = db.LeaseHouse.Find(LeaseID);
            ViewBag.leaseHouse = leaseHouse;
            return View();
        }
        /// <summary>
        /// 删除房屋信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult HouseDelete(int LeaseID)
        {
            var list = db.Lease.Where(p => p.LeaseID == LeaseID).ToList();
            if (list.Count>0)
            {
                return Content("<script >alert('该房间有租客存在，不能删除');window.history.go(-1);</script >", "text/html");
            }
            else
            {
                LeaseHouse leaseHouse = db.LeaseHouse.Find(LeaseID);
                db.LeaseHouse.Remove(leaseHouse);
                db.SaveChanges();
                return Content("<script >alert('删除成功');window.open('" + Url.Content("/LeaseHouse/Index") + "', '_self')</script >", "text/html");
            }
        }
        /// <summary>
        /// 租客信息
        /// </summary>
        /// <returns></returns>
        public ActionResult HouseUser(int LeaseID, string UserName)
        {
            LeaseHouse leaseHouse = db.LeaseHouse.Find(LeaseID);
            List<User> list = db.User.Where(p => p.UserName == UserName || p.UserName.Contains(UserName)).ToList();
            ViewBag.list = list;
            ViewBag.leaseHouse = leaseHouse;
            return View();
        }
        [HttpPost]
        public ActionResult HouseUser(Lease lease)
        {
            var startTime = lease.StartTime;
            var endTime = lease.EndTime;
            if (endTime<=startTime)
            {
                return Content("<script >alert('到期时间必须大于入住时间');window.history.go(-1);</script >", "text/html");
            }
            else
            {
                var House = db.LeaseHouse.Find(lease.LeaseID);
                House.IsLease = "是";
                db.Lease.Add(lease);
                db.SaveChanges();
                return Content("<script >alert('提交成功');window.open('" + Url.Content("/LeaseHouse/Index") + "', '_self')</script >", "text/html");
            }
        }
        /// <summary>
        /// 单人租房
        /// </summary>
        /// <returns></returns>
        public ActionResult SingleLease(string Position = "")
        {
            var list = db.Lease.Where(p => (p.LeaseHouse.LeaseType == 0 && p.LeaseHouse.Position == Position) || (p.LeaseHouse.LeaseType == 0 && p.LeaseHouse.Position.Contains(Position))).ToList();
            //var list = db.Lease.ToList();
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult SingleLease(int? LeaseID)
        {
            if (LeaseID == null)
            {
                var list = db.Lease.Where(p=>p.LeaseHouse.LeaseType==0).ToList();
                ViewBag.list = list;
                return View();
            }
            else
            {
                var lease = db.Lease.Where(p => p.LeaseID == LeaseID && p.LeaseHouse.LeaseType == 0).ToList();
                ViewBag.lease = lease;
                return View();
            }
        }
        /// <summary>
        /// 查询已超过租用时间的信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Overtime(string Position="")
        {
            DateTime nowTime = DateTime.Now;
            var list = db.Lease.Where(p => (p.EndTime < nowTime  && p.LeaseHouse.Position == Position && p.RentingState==0) || (p.EndTime < nowTime && p.LeaseHouse.Position.Contains(Position) && p.RentingState == 0)).ToList();
            ViewBag.list = list;
            return View();
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <returns></returns>
        public ActionResult SingleSee(int ID)
        {
            var lease = db.Lease.Find(ID);
            //var list = db.Lease.Where(p => (p.User.UserName == UserName && p.LeaseHouse.LeaseType == 0) || (p.User.UserName.Contains(UserName) && p.LeaseHouse.LeaseType == 0)).ToList();
            ViewBag.lease = lease;
            return View();
        }
        /// <summary>
        /// 修改单人出租信息
        /// </summary>
        /// <returns></returns>
        public ActionResult SingleEdit(int ID)
        {
            Lease lease = db.Lease.Find(ID);
            ViewBag.lease = lease;
            return View();
        }
        [HttpPost]
        public ActionResult SingleEdit(Lease lease)
        {
            var startTime = lease.StartTime;
            var endTime = lease.EndTime;
            var nowTime = DateTime.Now;
            if (endTime <= startTime)
            {
                return Content("<script >alert('到期时间必须大于入住时间');window.history.go(-1);</script >", "text/html");
            }
            else if(endTime<nowTime)
            {
                Lease lea = db.Lease.Find(lease.ID);
                lea.Time = lease.Time;
                lea.StartTime = lease.StartTime;
                lea.EndTime = lease.EndTime;
                lea.UserID = lease.UserID;
                lea.LeaseID = lease.LeaseID;
                lea.AdminID = lease.AdminID;
                lea.RentingState = 1;
                db.SaveChanges();
                ViewBag.lease = lea;
                return Content("<script >alert('修改成功');window.open('" + Url.Content("/LeaseHouse/SingleEdit?ID=" + lease.ID) + "', '_self')</script >", "text/html");
            }
            else
            {
                Lease lea = db.Lease.Find(lease.ID);
                lea.Time = lease.Time;
                lea.StartTime = lease.StartTime;
                lea.EndTime = lease.EndTime;
                lea.UserID = lease.UserID;
                lea.LeaseID = lease.LeaseID;
                lea.AdminID = lease.AdminID;
                lea.RentingState = 0;
                db.SaveChanges();
                ViewBag.lease = lea;
                return Content("<script >alert('修改成功');window.open('" + Url.Content("/LeaseHouse/SingleEdit?ID=" + lease.ID) + "', '_self')</script >", "text/html");
            }
        }
        /// <summary>
        /// 标记删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult SingleDelete(int ID)
        {
            var lease = db.Lease.Find(ID);
            lease.RentingState = 1;
            db.SaveChanges();
            //var list = db.Lease.Where(p => p.LeaseID == lease.LeaseID && p.RentingState==0).ToList();
            //if (list.Count == 0)
            //{
            //    var leaseHouse = db.LeaseHouse.Find(lease.LeaseID);
            //    leaseHouse.IsLease = "否";
            //}
            //db.SaveChanges();
            return Content("<script >alert('删除成功');window.open('" + Url.Content("/LeaseHouse/SingleLease") + "', '_self')</script >", "text/html");
        }
        public ActionResult SingleDelete1(int ID)
        {
            var lease = db.Lease.Find(ID);
            lease.RentingState = 1;
            db.SaveChanges();
            return Content("<script >alert('删除成功');window.open('" + Url.Content("/LeaseHouse/Together") + "', '_self')</script >", "text/html");
        }
        public ActionResult SingleBack(int ID)
        {
            var lease = db.Lease.Find(ID);
            lease.RentingState = 0;
            db.SaveChanges();
            return Content("<script >alert('恢复成功');window.open('" + Url.Content("/LeaseHouse/SingleLease") + "', '_self')</script >", "text/html");
        }
        public ActionResult SingleBack1(int ID)
        {
            var lease = db.Lease.Find(ID);
            lease.RentingState = 0;
            db.SaveChanges();
            return Content("<script >alert('恢复成功');window.open('" + Url.Content("/LeaseHouse/Together") + "', '_self')</script >", "text/html");
        }











        /// <summary>
        /// 合租信息
        /// </summary>
        /// <param name="Position"></param>
        /// <returns></returns>
        public ActionResult Together(string Position = "")
        {
            var list = db.Lease.Where(p => (p.LeaseHouse.LeaseType == 1 && p.LeaseHouse.Position == Position) || (p.LeaseHouse.LeaseType == 1 && p.LeaseHouse.Position.Contains(Position))).GroupBy(p => p.LeaseID).ToList();
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult Together(int? LeaseID)
        {
            if (LeaseID == null)
            {
                var list = db.Lease.Where(p => p.LeaseHouse.LeaseType == 1).GroupBy(p => p.LeaseID).ToList();
                ViewBag.list = list;
                return View();
            }
            else
            {
                var lease = db.Lease.Where(p => p.LeaseID == LeaseID && p.LeaseHouse.LeaseType == 1).GroupBy(p => p.LeaseID).ToList();
                ViewBag.lease = lease;
                return View();
            }
        }
        public ActionResult TogetherSee(int ID)
        {
            Lease lease = db.Lease.Find(ID);
            ViewBag.lease = lease;
            return View();
        }
        /// <summary>
        /// 合租信息编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult TogetherEdit(int ID)
        {
            Lease lease = db.Lease.Find(ID);
            ViewBag.lease = lease;
            return View();
        }
        [HttpPost]
        public ActionResult TogetherEdit(Lease lease)
        {
            var startTime = lease.StartTime;
            var endTime = lease.EndTime;
            var nowTime = DateTime.Now;
            if (endTime <= startTime)
            {
                return Content("<script >alert('到期时间必须大于入住时间');window.history.go(-1);</script >", "text/html");
            }
            else if (endTime < nowTime)
            {
                Lease lea = db.Lease.Find(lease.ID);
                lea.Time = lease.Time;
                lea.StartTime = lease.StartTime;
                lea.EndTime = lease.EndTime;
                lea.UserID = lease.UserID;
                lea.LeaseID = lease.LeaseID;
                lea.AdminID = lease.AdminID;
                lea.RentingState = 1;
                db.SaveChanges();
                ViewBag.lease = lea;
                return Content("<script >alert('修改成功');window.open('" + Url.Content("/LeaseHouse/TogetherEdit?ID=" + lease.ID) + "', '_self')</script >", "text/html");
            }
            else
            {
                Lease lea = db.Lease.Find(lease.ID);
                lea.Time = lease.Time;
                lea.StartTime = lease.StartTime;
                lea.EndTime = lease.EndTime;
                lea.UserID = lease.UserID;
                lea.LeaseID = lease.LeaseID;
                lea.AdminID = lease.AdminID;
                lea.RentingState = 0;
                db.SaveChanges();
                ViewBag.lease = lea;
                return Content("<script >alert('修改成功');window.open('" + Url.Content("/LeaseHouse/TogetherEdit?ID=" + lease.ID) + "', '_self')</script >", "text/html");
            }
        }
    }
}