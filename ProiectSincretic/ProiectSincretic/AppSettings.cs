using System;
using System.Collections.Generic;
using System.Text;

namespace ProiectSincretic
{
    public static class AppSettings
    {

        static string db1000 = "DB1000.db3"; public static string DB1000 { get { return db1000; } }
        static string db10000 = "DB10000.db3"; public static string DB10000 { get { return db10000; } }
        static string db100000 = "DB100000.db3"; public static string DB100000 { get { return db100000; } }

        static string dbnr1000 = "DBnr1000.txt"; public static string DBnr1000 { get { return dbnr1000; } }
        static string dbnr10000 = "DBnr10000.txt"; public static string DBnr10000 { get { return dbnr10000; } }
        static string dbnr100000 = "DBnr100000.txt"; public static string DBnr100000 { get { return dbnr100000; } }


        static string dbhibrid1000 = "DBhibrid1000.db3"; public static string DBhibrid1000 { get { return dbhibrid1000; } }
        static string dbhibrid10000 = "DBhibrid10000.db3"; public static string DBhibrid10000 { get { return dbhibrid10000; } }
        static string dbhibrid100000 = "DBhibrid100000.db3"; public static string DBhibrid100000 { get { return dbhibrid100000; } }


        static string mainFolder = ""; public static string MainFolder { get { return mainFolder; } set { mainFolder = value; } }

    }
}
