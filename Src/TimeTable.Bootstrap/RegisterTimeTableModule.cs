using Autofac;

namespace TimeTable.Bootstrap
{
    public static class RegisterTimeTableModule
    {
        public static void AddModule(this ContainerBuilder builder, string connectionString, string nlogConfigFile = "./nlog.config")
        {
            builder.RegisterModule(new TimeTableModule(connectionString, nlogConfigFile));
        }
    }
}