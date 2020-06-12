﻿using System;
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
            leaseHouse1.IsLease = leaseHouse.IsLease;
            leaseHouse1.Contacts = leaseHouse.Contacts;
            leaseHouse1.ContactsPhone = leaseHouse.ContactsPhone;
            db.SaveChanges();
            ViewBag.leaseHouse = leaseHouse1;
            return Content("<script >alert('修改成功');window.open('" + Url.Content("/LeaseHouse/HouseEdit?LeaseID="+leaseHouse1.LeaseID) + "', '_self')</script >", "text/html");
        }
    }
}