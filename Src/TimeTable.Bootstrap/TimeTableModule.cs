using System.Data;
using System.Data.Common;
using Autofac;
using Framework.Core;
using Framework.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TimeTable.Domain.Reserves;
using TimeTable.Facade.Query;
using TimeTable.Facade.Service;
using TimeTable.NLog;
using TimeTable.Persistence;
using TimeTable.Persistence.Repositories;

namespace TimeTable.Bootstrap
{
    internal class TimeTableModule : Module
    {
        private readonly string _connectionString;
        private readonly string _nlogConfigFile;

        public TimeTableModule(string connectionString, string nlogConfigFile = "./nlog.config")
        {
            _connectionString = connectionString;
            _nlogConfigFile = nlogConfigFile;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SystemClock>().As<ISystemClock>()
                .SingleInstance();

            builder.RegisterAssemblyTypes(typeof(CalendarRepository).Assembly)
                .Where(a => typeof(IRepository).IsAssignableFrom(a))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CalendarFacadeService).Assembly)
                .Where(a => typeof(IFacadeService).IsAssignableFrom(a))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CalendarFacadeQuery).Assembly)
                .Where(a => typeof(IFacadeService).IsAssignableFrom(a))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ReserveService).Assembly)
                .Where(a => typeof(IDomainService).IsAssignableFrom(a))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.Register<DbConnection>(z =>
            {
                var connection = new SqlConnection(_connectionString);
                connection.Open();
                return connection;
            }).InstancePerLifetimeScope().As<IDbConnection>().OnRelease(a => a.Close());


            builder.Register<TimeTableDbContext>(s =>
            {
                var options = new DbContextOptionsBuilder<TimeTableDbContext>()
                    .UseSqlServer(_connectionString)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    .Options;
                var context = new TimeTableDbContext(options);
                return context;
            }).InstancePerLifetimeScope().OnRelease(a => a.Dispose());

            builder.RegisterType<NLoggerService>().As<ILoggerService>()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(NLoggerService<>))
                .As(typeof(ILoggerService<>))
                .InstancePerLifetimeScope();

            NLogConfigure.Config(_nlogConfigFile);
        }
    }
}
