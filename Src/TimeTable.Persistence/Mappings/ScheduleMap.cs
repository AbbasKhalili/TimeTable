using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTable.Domain.Schedules;

namespace TimeTable.Persistence.Mappings
{
    internal class ScheduleMap : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedules");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.CalendarId).HasColumnName("CalendarId");
            builder.Property(a => a.Capacity).HasColumnName("Capacity");
            builder.Property(a => a.Time).HasColumnName("Time");

            builder.HasMany(a=>a.Reserves).WithOne(a=>a.Schedule).HasForeignKey(a=>a.ScheduleId);
        }
    }
}