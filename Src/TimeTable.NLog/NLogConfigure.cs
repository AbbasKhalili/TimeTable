using NLog;

namespace TimeTable.NLog
{
    public static class NLogConfigure
    {
        public static void Config(string nlogConfigFile = "./nlog.config")
        {
            LogManager.LoadConfiguration(nlogConfigFile).GetCurrentClassLogger();
        }
    }
}