using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TmsApi.Migrations
{
    /// <inheritdoc />
    public partial class RenameCapacityToMaxCapacity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DO $$
BEGIN
    IF EXISTS (
        SELECT 1
        FROM information_schema.columns
        WHERE table_schema = 'public'
          AND table_name = 'Courses'
          AND column_name = 'Capacity'
    )
    AND NOT EXISTS (
        SELECT 1
        FROM information_schema.columns
        WHERE table_schema = 'public'
          AND table_name = 'Courses'
          AND column_name = 'MaxCapacity'
    ) THEN
        ALTER TABLE ""Courses"" RENAME COLUMN ""Capacity"" TO ""MaxCapacity"";
    END IF;
END $$;
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DO $$
BEGIN
    IF EXISTS (
        SELECT 1
        FROM information_schema.columns
        WHERE table_schema = 'public'
          AND table_name = 'Courses'
          AND column_name = 'MaxCapacity'
    )
    AND NOT EXISTS (
        SELECT 1
        FROM information_schema.columns
        WHERE table_schema = 'public'
          AND table_name = 'Courses'
          AND column_name = 'Capacity'
    ) THEN
        ALTER TABLE ""Courses"" RENAME COLUMN ""MaxCapacity"" TO ""Capacity"";
    END IF;
END $$;
");
        }
    }
}
