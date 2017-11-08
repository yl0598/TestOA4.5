using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.WebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
 
        public ActionResult ValidateCode()
        {
            Common.ValidateCode validateCode = new Common.ValidateCode();
            string code= validateCode.CreateValidateCode(4);
            byte[] buffer=validateCode.CreateValidateGraphic(code);
            return File(buffer,"image/jpeg");
        }
    }
}