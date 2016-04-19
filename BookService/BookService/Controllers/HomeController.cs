using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;

namespace BookService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult KillApp()
        {
            SimpleLog.WriteStdOut("Kill-App");

            // Get the local time zone and the current local time and year.
            TimeZone localZone = TimeZone.CurrentTimeZone;
            DateTime currentDate = DateTime.Now;

            // Get the current Coordinated Universal Time (UTC) and UTC 
            // offset.
            DateTime currentUTC =
                localZone.ToUniversalTime(currentDate);
            TimeSpan currentOffset =
                localZone.GetUtcOffset(currentDate);

            ViewBag.TimestampInitiate = currentUTC.ToString("MMM-dd-yyyy HH:mm:ss");

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Thread.Sleep(3000);
                Environment.Exit(-1);
            }).Start();

            return View();
        }

        public ActionResult Index()
        {
            ViewBag.AppIndex = Environment.GetEnvironmentVariable("CF_INSTANCE_INDEX");
            ViewBag.AppIp = Environment.GetEnvironmentVariable("CF_INSTANCE_ADDR");

            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
