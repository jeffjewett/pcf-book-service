using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookService
{
    public class CloudSQLConnection
    {
        private static String actualConnection = String.Empty;

        public static String ConnectionString
        {
            get
            {
                if (actualConnection == String.Empty)
                {
                    Console.WriteLine(String.Format("CloudSQLConnection.ConnectionString"));
                    loadConnectionString();
                }
                return actualConnection;
            }
        }

        private static void loadConnectionString()
        {
            try
            {
                String vcapServicesEnvVariable = Environment.GetEnvironmentVariable("VCAP_SERVICES");

                if (vcapServicesEnvVariable != null)
                {
                    Dictionary<string, object> vcapServices = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(vcapServicesEnvVariable);

                    if (vcapServices != null)
                    {
                        var credentialList = (Newtonsoft.Json.Linq.JArray)vcapServices["user-provided"];
                        foreach (var currCredentials in credentialList)
                        {
                            var credentialDict = (Newtonsoft.Json.Linq.JObject)currCredentials["credentials"];
                            if (credentialDict != null)
                            {
                                // ref:
                                //"server=10.68.44.52;user id=h7RwvfDzRpnKFSxG;password=rUNfPngOGCqgqmrj;database=rUNfPngOGCqgqmrj;Persist Security Info=True";
                                //

                                //string host = (String)credentialDict["hostname"];
                                //string userid = (String)credentialDict["username"];
                                //string password = (String)credentialDict["password"];
                                //string catalog = (String)credentialDict["name"];

                                //actualConnection = String.Format("server={0};user id={1};password={2};database={3};Persist Security Info=True",
                                //    host,
                                //    userid,
                                //    password,
                                //    catalog);

                                actualConnection = (String)credentialDict["connectionString"];

                                if (actualConnection != null)
                                {
                                    Console.WriteLine(String.Format("SQL Connection URI: {0}", actualConnection));
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("loadConnectionString exception: ", ex.Message));
            }
        } //
    }
}