using System;

namespace TimeTable.Tests.Tools.CalendarTools
{
    public static class CalendarConst
    {
        public static DateTime Date = new DateTime(2021, 2, 10);
        public static bool IsHoliday = false;
        public static DateTime FromWorkTime = new DateTime(1, 1, 1, 9, 0, 0);
        public static DateTime ToWorkTime = new DateTime(1, 1, 1, 17, 0, 0);
    }

    public static class CalendarModifyConst
    {
        public static bool IsHoliday = true;
        public static DateTime FromWorkTime = new DateTime(1, 1, 1, 8, 0, 0);
        public static DateTime ToWorkTime = new DateTime(1, 1, 1, 13, 0, 0);
    }
}
