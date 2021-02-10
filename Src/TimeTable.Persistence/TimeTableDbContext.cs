using Microsoft.EntityFrameworkCore;
using TimeTable.Persistence.Mappings;
using TimeTable.Domain.Calendars;
using TimeTable.Domain.Reserves;
using TimeTable.Domain.Schedules;

namespace TimeTable.Persistence
{
    public class TimeTableDbContext : DbContext
    {

        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Reserve> Reserves { get; set; }


        public TimeTableDbContext(DbContextOptions<TimeTableDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyAllConfigurations(typeof(CalendarMap).Assembly);
        }
    }
}