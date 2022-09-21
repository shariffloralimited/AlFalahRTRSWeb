using System;
using System.Configuration;

namespace RTGS
{
    public class AppVariable
    {
        public static string ServerLogin = "server=" + ConfigurationManager.AppSettings["DBServer"] + ";database=RTGS;uid=floraweb;pwd=platinumfloor967";
    }
}
