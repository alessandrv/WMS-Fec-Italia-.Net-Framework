using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS_Fec_Italia.Net_Framework.Properties;


namespace WMS_Fec_Italia_MVC
{
    public static class DatabaseSettings
    {


      //  private static string dbIP = Settings.Default.dbIP;
      //  private static string dbPort = Settings.Default.dbPort;
      //  private static string dbUser = Settings.Default.dbUser;
      //  private static string dbPassword = Settings.Default.dbPassword;
      //  private static string dbName = Settings.Default.dbName;
        public static string ConnectionString = "Driver={IBM INFORMIX ODBC DRIVER};Server=asdb002f_ol11;Database=fec;Uid=informix;Pwd=informix;";

        //public static string ConnectionString = $"server={dbIP};port={dbPort};user={dbUser};database={dbName};password={dbPassword}";
    }
}
