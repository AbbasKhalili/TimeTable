using FluentMigrator;

namespace TimeTable.Migration
{
    [Migration(2)]
    public class _0002_Schedule : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Schedules")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("CalendarId").AsInt64()
                .WithColumn("Capacity").AsInt32()
                .WithColumn("Time").AsDateTime2();
        }
    }
}