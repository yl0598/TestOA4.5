﻿using OA.WebApp.Models;
using System.Web;
using System.Web.Mvc;

namespace OA.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new MyExecptionAttribute());//使用自定义异常处理过滤
        }
    }
}
