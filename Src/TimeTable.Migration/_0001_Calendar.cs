using FluentMigrator;

namespace TimeTable.Migration
{
    [Migration(1)]
    public class _0001_Calendar : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Calendars")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Date").AsDateTime2()
                .WithColumn("IsHoliday").AsBoolean()
                .WithColumn("FromWorkTime").AsDateTime2().Nullable()
                .WithColumn("ToWorkTime").AsDateTime2().Nullable();
        }
    }
}
