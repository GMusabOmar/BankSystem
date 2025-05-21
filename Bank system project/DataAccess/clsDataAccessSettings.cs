using System;
using System.Configuration;
namespace DataAccess
{
    internal class clsDataAccessSettings
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
    }
}
