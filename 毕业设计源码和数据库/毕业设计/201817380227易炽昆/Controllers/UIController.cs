﻿using System;
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
        public ActionResult Index()
        {
            return View();
        }
    }
}