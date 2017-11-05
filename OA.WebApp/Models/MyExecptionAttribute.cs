using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.WebApp.Models
{
    public class MyExecptionAttribute:HandleErrorAttribute
    {
        public static Queue<Exception> exceptionQueue = new Queue<Exception>();
        public override void OnException(ExceptionContext filterContext)
        {
            exceptionQueue.Enqueue(filterContext.Exception);//将捕获的异常信息写到队列

            filterContext.HttpContext.Response.Redirect("/Error.html");


            base.OnException(filterContext);
        }
    }
}