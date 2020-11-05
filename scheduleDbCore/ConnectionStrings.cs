using System;
using System.Collections.Generic;
using System.Text;

namespace scheduleDbCore
{
    public static class ConnectionStrings
    {
        public static string Azure
        {
            get
            {
                return @"*_*";
            }
        }

        public static string Local
        {
            get
            {
                return @"Server=DESKTOP-LSUK7PO\SQLEXPRESS;initial catalog=scheduleDb;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            }
        }
    }
}
