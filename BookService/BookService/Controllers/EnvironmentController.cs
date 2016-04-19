using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookService.Models;

namespace BookService.Controllers
{
    public class EnvironmentController : Controller
    {
        private static String RequestIp = String.Empty;
        private static String VcapServices = String.Empty;

        // Get environment variables and dump them    
        private IEnumerable<KeyValuePair<string, string>> GetVcapVars(bool all)
        {
            var vcapVariables = from DictionaryEntry entry in Environment.GetEnvironmentVariables()
                                where (all || entry.Key.ToString().StartsWith("VCAP"))
                                select new KeyValuePair<string, string>(entry.Key.ToString(), entry.Value.ToString());


            // ref:
            //OUT Key: VCAP_SERVICES, Value: { "user-provided":[{"name":"pcf-sql-connection","label":"user-provided","tags":[],"credentials":{"connectionString":"Server=tcp:trkzkp608j.database.windows.net,1433;Database=ContosoUniversity2;User ID=pivotal@trkzkp608j;Password=paasword1!;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;"},"syslog_drain_url":""}]}

            return vcapVariables;
        }

        // GET: Environment
        public ActionResult Index(string all)
        {

            IEnumerable<KeyValuePair<string, string>> vcapVars = GetVcapVars(all != null);

            return View(new EnvironmentModel { VcapVariables = vcapVars });
        }
    }
}