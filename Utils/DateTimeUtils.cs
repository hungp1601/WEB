using System;
using System.Globalization;
namespace NHNT.Utils
{

    public static class DateTimeUtils
    {

        public static DateTime GetCurrentTime()
        {
            string dateTimeString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime currentTime = DateTime.ParseExact(dateTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            return currentTime;
        }
    }
}