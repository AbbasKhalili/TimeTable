using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTable.Domain.Calendars;

namespace TimeTable.Persistence.Mappings
{
    internal class CalendarMap : IEntityTypeConfiguration<Calendar>
    {
        public void Configure(EntityTypeBuilder<Calendar> builder)
        {
            builder.ToTable("Calendars");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.IsHoliday).HasColumnName("IsHoliday");
            builder.Property(a => a.Date).HasColumnName("Date");
            builder.Property(a => a.FromWorkTime).HasColumnName("FromWorkTime");
            builder.Property(a => a.ToWorkTime).HasColumnName("ToWorkTime");

            builder.HasMany(a => a.Schedules).WithOne(a => a.Calendar).HasForeignKey(a => a.CalendarId);
        }
    }
}
