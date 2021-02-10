using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTable.Domain.Reserves;

namespace TimeTable.Persistence.Mappings
{
    internal class ReserveMap : IEntityTypeConfiguration<Reserve>
    {
        public void Configure(EntityTypeBuilder<Reserve> builder)
        {
            builder.ToTable("Reserves");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.ScheduleId).HasColumnName("ScheduleId");
            builder.Property(a => a.Name).HasColumnName("Name");

        }
    }
}