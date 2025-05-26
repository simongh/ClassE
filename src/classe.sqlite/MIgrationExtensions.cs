using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassE
{
    internal static class MIgrationExtensions
    {
        public static void AddRowVersion(this MigrationBuilder migrationBuilder, string tableName)
        {
            migrationBuilder.Sql(
@$"CREATE TRIGGER Set{tableName}TimestampOnUpdate
AFTER UPDATE ON {tableName}
BEGIN
    UPDATE {tableName}
    SET RowVersion = randomblob(8)
    WHERE rowid = NEW.rowid;
END");
        }
    }
}