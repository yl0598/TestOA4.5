using Common.Logging;
using OA.WebApp.Models;
using Spring.Web.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OA.WebApp
{
    public class MvcApplication :SpringMvcApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();//读取配置信息
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string fileLogPath = Server.MapPath("/Log/");
            //开启一个线程扫描日志队列
            ThreadPool.QueueUserWorkItem(
                (a) => {
                    while (true)//不断扫描日志队列
                    {
                        if (MyExecptionAttribute.exceptionQueue.Count() > 0)
                        {
                           Exception ex= MyExecptionAttribute.exceptionQueue.Dequeue();//出队
                            if (ex != null)
                            {
                                //string fileName = DateTime.Now.ToString("yyyy-MM-dd")+ ".txt";

                                //File.AppendAllText(fileLogPath + fileName, ex.ToString(),Encoding.Default);//将异常写的文件中
                                ILog logger = LogManager.GetLogger("errorMessage");
                                logger.Error(ex);//将异常信息写到磁盘上

                            }
                            else
                            {
                                Thread.Sleep(3000);
                            }
                        }

                        else
                        {
                            Thread.Sleep(3000);//如果队列没有数据，当前线程休息，避免造成CPU空转
                        }
                            
                    }

                },fileLogPath
                
                );
        }
    }
}
