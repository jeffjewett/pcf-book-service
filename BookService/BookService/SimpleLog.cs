using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookService
{
    public class SimpleLog
    {
        public static void WriteStdOut(String uri)
        {
            try
            {
                string appIp = Environment.GetEnvironmentVariable("CF_INSTANCE_ADDR");
                string appIndex = Environment.GetEnvironmentVariable("CF_INSTANCE_INDEX");      

                Console.WriteLine(String.Format("uri: {0}|addr: {1}|app index: {2}|{3}",
                    uri,
                    appIp,
                    appIndex,
                    DateTime.Now.ToString("MMM-dd-yyyy HH:mm:ss.ffffff")));
            }
            catch (Exception) { }
        }
    }
}