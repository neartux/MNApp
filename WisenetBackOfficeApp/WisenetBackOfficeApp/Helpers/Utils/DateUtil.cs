using System;

namespace WisenetBackOfficeApp.Helpers.Utils
{
    static class DateUtil {
        public static DateTime UnixDateToDateTime(long _UnixDate) {
            DateTime startDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return startDate.AddMilliseconds(_UnixDate).ToLocalTime();
        }

        public static long DateTimeToUnixDate(DateTime date) {
            const double LongAdj = 1000.0;
            DateTime mydate = Convert.ToDateTime(date).ToLocalTime();
            DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).ToLocalTime();
            return (long)((mydate - UnixEpoch).TotalSeconds * LongAdj);
        }
    }
}
    