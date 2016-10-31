using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSender
{
    public static class DataConfigs
    {
        public static string ReadSetting(string key)
       {

			return ConfigurationManager.AppSettings.AllKeys.Contains(key) ? ConfigurationManager.AppSettings[key] : "AIzaSyCbcyy8H-NGRRQYIYgdlnOnyBHGh2EeV0k";
        }

    }
}
