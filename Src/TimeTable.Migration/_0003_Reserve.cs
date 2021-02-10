using FluentMigrator;

namespace TimeTable.Migration
{
    [Migration(3)]
    public class _0003_Reserve : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Reserves")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("ScheduleId").AsInt64()
                .WithColumn("Name").AsString();
        }
    }
}