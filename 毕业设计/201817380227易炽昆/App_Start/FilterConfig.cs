﻿using System.Web;
using System.Web.Mvc;

namespace _201817380227易炽昆
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
