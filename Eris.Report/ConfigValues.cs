using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Eris.Reporter
{
    public class ConfigValues
    {
        public static string constr = "Server=.;DataBase=DpaTotalSystem2000;User ID=sa;Password=123";
        internal static string GetRooz()
        {
            string result = "نامعلوم";

            string rooz = DateTime.Today.DayOfWeek.ToString();
            switch (rooz)
            {
                case "Sunday":
                    result = "يكشنبه";
                    break;
                case "Monday":
                    result = "دوشنبه";
                    break;
                case "Tuesday":
                    result = "سه شنبه";
                    break;
                case "Wednesday":
                    result = "چهارشنبه";
                    break;
                case "Thursday":
                    result = "پنج شنبه";
                    break;
                case "Saturday":
                    result = "شنبه";
                    break;
            }
            return result;
        }
        public static Eris.Entity.UserEntity User = new Entity.UserEntity();

        public static string CnnName;
    }
}


