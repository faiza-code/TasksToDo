using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasksToGo.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityWithCustomUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "todoTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 12, 15, 15, 22, 36, 399, DateTimeKind.Utc).AddTicks(1875),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 12, 15, 15, 21, 56, 138, DateTimeKind.Utc).AddTicks(9178));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TaskCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 12, 15, 15, 22, 36, 399, DateTimeKind.Utc).AddTicks(66),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 12, 15, 15, 21, 56, 138, DateTimeKind.Utc).AddTicks(7811));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "todoTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 12, 15, 15, 21, 56, 138, DateTimeKind.Utc).AddTicks(9178),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 12, 15, 15, 22, 36, 399, DateTimeKind.Utc).AddTicks(1875));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TaskCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 12, 15, 15, 21, 56, 138, DateTimeKind.Utc).AddTicks(7811),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 12, 15, 15, 22, 36, 399, DateTimeKind.Utc).AddTicks(66));
        }
    }
}
