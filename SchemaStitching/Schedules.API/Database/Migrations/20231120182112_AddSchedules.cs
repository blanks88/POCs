using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Schedules.API.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSchedules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Tenant = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Note = table.Column<string>(type: "character varying(8000)", maxLength: 8000, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "DeletedAt", "ModifiedAt", "Note", "Tenant", "Title" },
                values: new object[,]
                {
                    { new Guid("38ec4717-2743-4e32-99ee-1d30e39ce7ed"), new Guid("402ab577-379f-4e42-86ea-9ecf2e454dd5"), new DateTime(2023, 11, 20, 12, 21, 12, 670, DateTimeKind.Utc).AddTicks(2090), null, null, "Oklahoma #2", "Oklahoma", "The Oklahoma Schedule #2" },
                    { new Guid("6ece7385-c407-410f-b03e-e961cb76cd56"), new Guid("be4cc0d7-029c-45b6-a121-726a53ccd21a"), new DateTime(2023, 11, 20, 12, 21, 12, 670, DateTimeKind.Utc).AddTicks(2080), null, null, "Oklahoma #1", "Oklahoma", "The Oklahoma Schedule #1" },
                    { new Guid("855b6f71-9458-4de2-8c97-671c61ae1591"), new Guid("0fdc6594-102f-4f05-872b-6746b65bdee9"), new DateTime(2023, 11, 20, 12, 21, 12, 670, DateTimeKind.Utc).AddTicks(2040), null, null, "Sidearm u note", "Sidearmu", "The Sidearm Schedule" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");
        }
    }
}
